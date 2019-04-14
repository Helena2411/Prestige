using System;
using Prestige.RoyalRent.Common;
using Prestige.RoyalRent.Client.Business;
using Prestige.RoyalRent.Client.Business.Controllers;

namespace Prestige.RoyalRent.Client.Console
{
    class CustomerAction
    {
        private readonly CarController _carController;

        public CustomerAction(CarController carController)
        {
            _carController = carController;
        }

        public void ChoiceActionByCustomer(Customer customer)
        {
            while (true)
            {
                try
                {
                    string answer = System.Console.ReadLine();
                    
                    if (answer == "1")
                    {
                        var availableCars = _carController.GetAvailableCar();
                        System.Console.WriteLine("You can choose car by number");
                        System.Console.WriteLine("Available cars:");
                        Writer.PrintArray(availableCars);
                        string index = System.Console.ReadLine();
                        _carController.CheckOccupationOfCarAndSetConnectionWithCustomer(availableCars[Convert.ToInt32(index) - 1], customer);
                        System.Console.WriteLine("You occupied a car! Have a good day!");
                        break;
                    }
                    else if (answer == "2")
                    {
                        var occupiedCarByCustomer = _carController.GetOccupiedCarsByCustomer(customer);
                        System.Console.WriteLine("You can choose car by number");
                        System.Console.WriteLine("Your current cars:");
                        Writer.PrintArray(occupiedCarByCustomer);
                        string index = System.Console.ReadLine();
                        _carController.CheckRefundOfCarAndSetConnectionWithCustomer(occupiedCarByCustomer[Convert.ToInt32(index) - 1], customer);
                        System.Console.WriteLine("You retrieved a car! Have a good day!");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Incorrect! Bye!");
                    }
                }
                catch (RoyalRentException ex)
                {
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
