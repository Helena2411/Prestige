using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class Consultant
    {
        public List<Car> GetAvailableCar(RoyalCarContext json)
        {
            Console.WriteLine("Available cars:");
            List<Car> availableCars = new List<Car>();
            for (int i = 0; i < json.Cars.Count; i++)
            {
                if (json.Cars[i].CustomerId == "")
                {
                    availableCars.Add(json.Cars[i]);
                    //Console.WriteLine($"{i + 1}. {json.Cars[i]}");
                }
            }
            return availableCars;
        }

        public List<Car> GetOccupiedCarsByCustomer(RoyalCarContext json, Customer customer)
        {
            List<Car> occupiedCars = new List<Car>();
            Console.WriteLine("Your current cars:");
            for (int i = 0; i < json.Cars.Count; i++)
            {
                if (customer.Id == json.Cars[i].CustomerId)
                {
                    occupiedCars.Add(json.Cars[i]);
                    //Console.WriteLine($"{i + 1}. {json.Cars[i]}");
                }
            }
            return occupiedCars;
        }
    }
}
