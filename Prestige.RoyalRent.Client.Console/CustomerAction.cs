using System;
using Prestige.RoyalRent.Common;
using Prestige.RoyalRent.Client.Business;
using Prestige.RoyalRent.Client.Business.Controllers;
using System.Collections.Generic;

namespace Prestige.RoyalRent.Client.Console
{
    class CustomerAction
    {
        private readonly CarController _carController;
        public event CarController.GetCars getCars;

        public CustomerAction(CarController carController)
        {
            _carController = carController;
        }

        public void ChoiceActionByCustomer(Customer<string> customer)
        {
            while (true)
            {
                try
                {
                    string answer = System.Console.ReadLine();
                    
                    if (answer == "1")
                    {
                        getCars = user => _carController.GetAvailableCars(user);
                        System.Console.WriteLine("You can choose car by number");
                        System.Console.WriteLine("Available cars:");
                        var availableCars = getCars(customer);
                        Writer.PrintArray(availableCars);
                        string index = System.Console.ReadLine();
                        _carController.OccupyOfCarByCustomerAndSaveChanges(availableCars[Convert.ToInt32(index) - 1], customer);
                        System.Console.WriteLine("You occupied a car! Have a good day!");
                        break;
                    }
                    else if (answer == "2")
                    {
                        getCars = user => _carController.GetOccupiedCarsByCustomer(user);
                        System.Console.WriteLine("You can choose car by number");
                        System.Console.WriteLine("Your current cars:");
                        var occupiedCarByCustomer = getCars(customer);
                        Writer.PrintArray(occupiedCarByCustomer);
                        string index = System.Console.ReadLine();
                        _carController.RefundOfCarByCustomerAndSaveChanges(occupiedCarByCustomer[Convert.ToInt32(index) - 1]);
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
