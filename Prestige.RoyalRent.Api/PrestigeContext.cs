using Microsoft.EntityFrameworkCore;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Api
{
    public class PrestigeContext : DbContext
    {
        public DbSet<Customer<string>> Customers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public PrestigeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
