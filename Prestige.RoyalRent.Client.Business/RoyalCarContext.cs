using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace Prestige.RoyalRent.Client.Business
{
    public class RoyalCarContext
    {
        private static RoyalCarContext _context;

        private static readonly IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

        private static readonly string FileName = config["FileName"];

        public static RoyalCarContext Context
        {
            get { return _context ?? (_context = JsonToArrayObject.DeserializeArray(FileName)); }
        }

        public List<Car> Cars { get; set; }
         
        public List<Customer<string>> Customers { get; set; }

        public void SaveChanges()
        {
            JsonToArrayObject.SerializeArray(_context, FileName);
        }
    }
}
