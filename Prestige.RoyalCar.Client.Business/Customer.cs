using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar.Client.Business
{
    public class Customer
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public Customer(string name)
        {
            Name = name;
            Id = Guid.NewGuid().ToString("N");
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
