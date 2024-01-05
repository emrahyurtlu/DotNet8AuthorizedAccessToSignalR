using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net8Identity.Data
{
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
                    Email= "test@test.com",
                    PasswordHash= hasher.HashPassword(null,"Password12*")
                });

            base.OnModelCreating(builder);
        }
    }
}
