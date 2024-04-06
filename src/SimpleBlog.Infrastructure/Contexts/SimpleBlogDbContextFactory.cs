using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SimpleBlog.Infrastructure.Contexts;

public class SimpleBlogDbContextFactory : IDesignTimeDbContextFactory<SimpleBlogDbContext>
{
    public SimpleBlogDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json")
             .Build();
        var builder = new DbContextOptionsBuilder<SimpleBlogDbContext>();
        builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        return new SimpleBlogDbContext(builder.Options);
    }
}
