using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class Customer
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
            Id = Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return $"{Name} - {Email}";
        }
    }
}
