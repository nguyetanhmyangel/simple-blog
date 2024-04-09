using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Core.Constants;
using SimpleBlog.Core.Domain.Identity;
using SimpleBlog.Core.Dtos.Auth;
using SimpleBlog.Core.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SimpleBlog.Api.Controllers.AdminApi;
[Route("api/admin/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    public AuthController(UserManager<AppUser> userManager,
    SignInManager<AppUser> signInManager,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    [HttpPost]
    public async Task<ActionResult<AuthenticatedResponse>> Login([FromBody] AuthenticatedRequest request)
    {
        //Authentication
        if (request == null)
        {
            return BadRequest("Invalid request");
        }

        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user == null || user.IsActive == false || user.LockoutEnabled)
        {
            return Unauthorized();
        }

        var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, false, true);
        if (!result.Succeeded)
        {
            return Unauthorized();
        }

        //Authorization
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new[]
        {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(UserClaims.Id, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(UserClaims.FirstName, user.FirstName),
                    new Claim(UserClaims.Roles, string.Join(";", roles)),
                    //new Claim(UserClaims.Permissions, JsonSerializer.Serialize(permissions)),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(30);
        await _userManager.UpdateAsync(user);

        return Ok(new AuthenticatedResponse()
        {
            Token = accessToken,
            RefreshToken = refreshToken
        });
    }
}
