using System;
using Prestige.RoyalRent.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using Prestige.RoyalRent.Client.Business.Models;

namespace Prestige.RoyalRent.Client.Console
{
    public class CustomerAction
    {
        private readonly RoyalRentHttpClient _royalRentHttpClient;


        public CustomerAction()
        {
            _royalRentHttpClient = new RoyalRentHttpClient();
        }

        public async Task ChoiceActionByCustomerAsync(Customer user)
        {
            var customer = JsonConvertPrestige.Deserialize<Customer>(_royalRentHttpClient.GetCustomer(user).Result);

            while (true)
            {
                try
                {
                    System.Console.WriteLine("Choose operation:\n 1. Occupy car\n 2. Refund car\n ...Any other key for exit");
                    var answer = System.Console.ReadLine();
                    System.Console.WriteLine("You can choose car by number");

                    if (answer.Equals("1"))
                    {
                        System.Console.WriteLine("Available cars:");
                        var requestAvailableCars = _royalRentHttpClient.GetAvailableCars(customer.Id, true);
                        var availableCars = JsonConvertPrestige.Deserialize<List<Car>>(requestAvailableCars.Result);
                        WriteCars(availableCars);
                        var index = System.Console.ReadLine();
                        await _royalRentHttpClient.OccupyCar (Convert.ToInt32(index), customer.Id);
                        System.Console.WriteLine("You occupied a car! Have a good day!");
                    }
                    else if (answer.Equals("2"))
                    {
                        System.Console.WriteLine("Your current cars:");
                        var requestOccupiedCars = _royalRentHttpClient.GetAvailableCars(customer.Id, false);
                        var occupiedCarByCustomer = JsonConvertPrestige.Deserialize<List<Car>>(requestOccupiedCars.Result);
                        WriteCars(occupiedCarByCustomer);
                        var index = System.Console.ReadLine();
                        await _royalRentHttpClient.RefundCar(Convert.ToInt32(index));
                        System.Console.WriteLine("You retrieved a car! Have a good day!");
                    }
                    else
                    {
                        System.Console.WriteLine("Have a nice day! Bye!");
                        break;
                    }
                }
                catch (RoyalRentException ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void WriteCars(IEnumerable<Car> cars)
        {
            foreach (var car in cars)
            {
                System.Console.WriteLine(car.Id + " " + car);
            }
        }
    }
}
