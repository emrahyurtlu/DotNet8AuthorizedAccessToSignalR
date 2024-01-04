using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Net8Identity.Data
{
    public class ProdyumDbContext: IdentityDbContext<ProdyumUser>
    {
        public ProdyumDbContext(DbContextOptions<ProdyumDbContext> options): base(options)
        {
            
        }

        public DbSet<ProdyumUser> ProdyumUsers { get; set; }
    }
}
