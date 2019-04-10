using System.Collections.Generic;
using System.Configuration;

namespace Prestige.RoyalRent.Client.Business
{
    internal class RoyalCarContext
    {
        private static RoyalCarContext _context;

        private static readonly string FileName = ConfigurationManager.AppSettings["FileName"];

        public static RoyalCarContext Context
        {
            get { return _context ?? (_context = JsonToArrayObject.DeserializeArray(FileName)); }
        }

        public List<Car> Cars { get; set; }
         
        public List<Customer> Customers { get; set; }

        public void SaveChanges()
        {
            JsonToArrayObject.SerializeArray(_context, FileName);
        }
    }
}
