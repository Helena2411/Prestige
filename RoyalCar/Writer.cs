using Prestige.RoyalCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent
{
    class Writer
    {
        public static void PrintArray(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i+1}. {cars[i]}");
            }
        }

        public static void PrintAvailableCar(RoyalCarContext json, Customer customer)
        {
            Console.WriteLine("Available for you cars and occupied you:");
            for (int i = 0; i < json.Cars.Count; i++)
            {
                if (json.Cars[i].IsOccupied | customer.Id == json.Cars[i].CustomerId)
                {
                    Console.WriteLine($"{i + 1}. {json.Cars[i]}");
                }
            }
        }
    }
}
