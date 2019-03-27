using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar
{
    class Customer
    {
        public string Name { get; set; }

        public String IdOfCustomer { get; set; }

        public Customer(string name)
        {
            Name = name;
            IdOfCustomer = Guid.NewGuid().ToString("N");
            Console.WriteLine(IdOfCustomer);
        }

        public override string ToString()
        {
            return $"{IdOfCustomer} - {Name}";
        }
    }
}
