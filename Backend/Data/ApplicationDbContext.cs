using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net8Identity.Data;

public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<ApplicationUser> ProdyumUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                UserName = "test@test.com",
                NormalizedUserName = "test@test.com".ToUpper(),
                Email = "test@test.com",
                NormalizedEmail = "test@test.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null,"Password12*"),
            });

        base.OnModelCreating(builder);
    }
}
