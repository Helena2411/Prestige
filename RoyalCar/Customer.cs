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

        public Customer(string name)
        {
            Name = name;
        }

        public void OccupyCar(List<Car> cars, int index)
        {
            if (!cars[index].IsOccupied)
            {
                Console.WriteLine("\n" + cars[index].Brand + " is occupy");
            }
            else
            {
                cars[index].IsOccupied = false;
                Console.WriteLine("\n" + cars[index].Brand + " is already occupy");
            } 
        }

        public void RetrieveCar(List<Car> cars, int index)
        {
            if (!cars[index].IsOccupied)
            {
                cars[index].IsOccupied = true;
                Console.WriteLine("\n" + cars[index].Brand + " is retrieve");
            }
            else
            {
                Console.WriteLine("\n" + cars[index].Brand + " is already retrieve");
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
