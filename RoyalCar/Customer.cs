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

        public Customer(string name)
        {
            this.name = name;
        }

        public void setName(string name) {
            this.name = name;

        }
        public string getName()
        {
            return name;
        }

        public List<Car> occupy(List<Car> cars, int index) {
            if (cars[index].getOccypancy())
            {
                cars[index].setOccypancy(false);
                Console.WriteLine("\n" + cars[index].getBrand() +  " is occupy");
            }
            else Console.WriteLine("\n" + cars[index].getBrand() + " is already occupy");
            return cars; 
        }
        public List<Car> retrieve(List<Car> cars, int index)
        {
            if (!cars[index].getOccypancy())
            {
                cars[index].setOccypancy(true);
                Console.WriteLine("\n" + cars[index].getBrand() + " is retrieve");
            }
            else Console.WriteLine("\n" + cars[index].getBrand() + " is already retrieve");
            return cars;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
