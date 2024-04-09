
namespace SimpleBlog.Core.Dtos.Auth;
public class AuthenticatedRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
