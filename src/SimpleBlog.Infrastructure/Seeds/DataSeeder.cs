using Microsoft.AspNetCore.Identity;
using SimpleBlog.Core.Domain.Identity;
using SimpleBlog.Infrastructure.Contexts;

namespace SimpleBlog.Infrastructure.Seeds;
public class DataSeeder
{
    public async Task SeedAsync(SimpleBlogDbContext context)
    {
        var passwordHasher = new PasswordHasher<AppUser>();

        var rootAdminRoleId = Guid.NewGuid();
        if (!context.Roles.Any())
        {
            await context.Roles.AddAsync(new AppRole()
            {
                Id = rootAdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
                DisplayName = "Quản trị"
            });
            await context.SaveChangesAsync();
        }

        if (!context.Users.Any())
        {
            var userId = Guid.NewGuid();
            var user = new AppUser()
            {
                Id = userId,
                FirstName = "Anh",
                LastName = "Nguyet",
                Email = "nguyetanhmyangel@gmail.com.vn",
                NormalizedEmail = "NGUYETANHMYANGEL@TEDU.COM.VN",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                IsActive = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = false,
                DateCreated = DateTime.Now
            };
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin@123");
            await context.Users.AddAsync(user);

            await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
            {
                RoleId = rootAdminRoleId,
                UserId = userId,
            });
            await context.SaveChangesAsync();
        }
    }
}
