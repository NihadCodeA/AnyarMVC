using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnyarMVC.Models
{
    public class AnyarDB : IdentityDbContext
    {
        public AnyarDB(DbContextOptions<AnyarDB> options):base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSocialMediaAccount> SocialMediaAccounts { get; set; }

        public DbSet<AppUser> Users { get; set; }
    }
}
