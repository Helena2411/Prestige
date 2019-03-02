using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar
{
    class Customer
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set {
                name = value;
            }
        }

        public Customer(string name)
        {
            this.name = name;
        }

        public List<Car> OccupyCar(List<Car> cars, int index) {
            if (cars[index].Occupancy)
            {
                cars[index].Occupancy = false;
                Console.WriteLine("\n" + cars[index].Brand +  " is occupy");
            }
            else Console.WriteLine("\n" + cars[index].Brand + " is already occupy");
            return cars; 
        }
        public List<Car> RetrieveCar(List<Car> cars, int index)
        {
            if (!cars[index].Occupancy)
            {
                cars[index].Occupancy = true; ;
                Console.WriteLine("\n" + cars[index].Brand + " is retrieve");
            }
            else Console.WriteLine("\n" + cars[index].Brand + " is already retrieve");
            return cars;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
