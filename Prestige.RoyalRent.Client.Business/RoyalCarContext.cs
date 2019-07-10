using System.Collections.Generic;
using System.Configuration;

namespace Prestige.RoyalRent.Client.Business
{
    public class RoyalCarContext
    {
        private static RoyalCarContext _context;

        private static readonly string FileName = ConfigurationManager.AppSettings["FileName"];

        private static readonly string FileName = WebHost.;

        public static RoyalCarContext Context
        {
            get { return _context ?? (_context = JsonToArrayObject.DeserializeArray("D:\\С#\\RoyalRent\\Prestige.RoyalRent.Client.Console\\bin\\Debug\\file.json")); }
        }

        public List<Car> Cars { get; set; }
         
        public List<Customer<string>> Customers { get; set; }

        public void SaveChanges()
        {
            JsonToArrayObject.SerializeArray(_context, FileName);
        }
    }
}
