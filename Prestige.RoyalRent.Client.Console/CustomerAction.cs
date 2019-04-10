using System;
using Prestige.RoyalCar.Common;
using Prestige.RoyalRent.Client.Business.Controllers;
using Prestige.RoyalRent.Client.Console;

namespace Prestige.RoyalRent
{
    class CustomerAction
    {
        private readonly CarController _carController;

        public CustomerAction(CarController carController)
        {
            _carController = carController;
        }

        public void ChoiceActionByCustomer(string answer, RoyalCar.Common.Models.Customer customer)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("You can choose car by number");
                    if (answer == "1")
                    {
                        var availableCars = _carController.GetAvailableCar();
                        Writer.PrintArray(availableCars);
                        string index = Console.ReadLine();
                        _carController.CheckOccupationOfCarAndSetConnectionWithCustomer(availableCars[Convert.ToInt32(index) - 1], customer);
                        Console.WriteLine("You occupied a car! Have a good day!");
                    }
                    else if (answer == "2")
                    {
                        var occupiedCarByCustomer = _carController.GetOccupiedCarsByCustomer(customer);
                        Writer.PrintArray(occupiedCarByCustomer);
                        string index = Console.ReadLine();
                        _carController.CheckRefundOfCarAndSetConnectionWithCustomer(occupiedCarByCustomer[Convert.ToInt32(index) - 1], customer);
                        Console.WriteLine("You retrieved a car! Have a good day!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect! Bye!");
                    }
                    Console.ReadLine();
                    break;
                }
                catch (RoyalCarException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
