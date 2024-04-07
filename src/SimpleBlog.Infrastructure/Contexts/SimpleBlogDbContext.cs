using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBlog.Core.Domain.Contracts;
using SimpleBlog.Core.Domain.Entities;
using SimpleBlog.Core.Domain.Identity;

namespace SimpleBlog.Infrastructure.Contexts;
public class SimpleBlogDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public SimpleBlogDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Post> Posts { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
    public DbSet<PostTag> PostTags { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostActivityLog> PostActivityLogs { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<PostInSeries> PostInSeries { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims")
        .HasKey(x => x.Id);

        builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

        builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles")
        .HasKey(x => new { x.RoleId, x.UserId });

        builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens")
           .HasKey(x => new { x.UserId });

        //All Decimals will have 18,2 Range
        foreach (var property in builder.Model.GetEntityTypes()
        .SelectMany(t => t.GetProperties())
        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }
        base.OnModelCreating(builder);
    }

    //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //var entries = ChangeTracker
    //    .Entries()
    //    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

    //foreach (var entityEntry in entries)
    //{
    //    var dateCreatedProp = entityEntry.Entity.GetType().GetProperty("CreatedAt");
    //    if (entityEntry.State == EntityState.Added
    //        && dateCreatedProp != null)
    //    {
    //        dateCreatedProp.SetValue(entityEntry.Entity, DateTime.Now);
    //    }
    //    var modifiedDateProp = entityEntry.Entity.GetType().GetProperty("LastUpdateAt");
    //    if (entityEntry.State == EntityState.Modified
    //        && modifiedDateProp != null)
    //    {
    //        modifiedDateProp.SetValue(entityEntry.Entity, DateTime.Now);
    //    }
    //}
    //OnBeforeSaving();
    //return await base.SaveChangesAsync(cancellationToken);
    //}

    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //    OnBeforeSaving();
    //    return  base.SaveChangesAsync(cancellationToken);
    //}


    private void OnBeforeSaving()
    {
        var entries = ChangeTracker.Entries();
        foreach (var entry in entries)
        {
            if (entry.Entity is IAuditableEntity trackable)
            {
                var now = DateTime.UtcNow;
                //var user = GetCurrentUser();
                switch (entry.State)
                {
                    case EntityState.Modified:
                        trackable.LastUpdatedAt = now;
                        //trackable.LastUpdatedBy = user;
                        break;

                    case EntityState.Added:
                        trackable.CreatedAt = now;
                        //trackable.CreatedBy = user;                     
                        break;
                }
            }
        }
    }
}
