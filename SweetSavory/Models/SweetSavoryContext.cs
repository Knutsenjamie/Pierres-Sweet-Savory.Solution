using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetSavory.Models
{
    public class SweetSavoryContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<FlavorTreat> FlavorTreats { get; set; }

        public SweetSavoryContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        optionsBuilder.UseLazyLoadingProxies();
        }
    }
}