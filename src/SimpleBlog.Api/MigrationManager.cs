using Microsoft.EntityFrameworkCore;
using SimpleBlog.Infrastructure.Contexts;
using SimpleBlog.Infrastructure.Seeds;

namespace SimpleBlog.Api;

public static class MigrationManager
{
    public static WebApplication MigrateDatabase(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            using (var context = scope.ServiceProvider.GetRequiredService<SimpleBlogDbContext>())
            {
                context.Database.Migrate();
                new DataSeeder().SeedAsync(context).Wait();
            }
        }
        return app;
    }
}
