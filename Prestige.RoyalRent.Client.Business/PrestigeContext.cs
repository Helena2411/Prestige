using Microsoft.EntityFrameworkCore;
using Prestige.RoyalRent.Client.Business.Models;

namespace Prestige.RoyalRent.Client.Business
{
    public class PrestigeContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public PrestigeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
