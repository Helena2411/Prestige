using Prestige.RoyalRent.Client.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent
{
    class CustomerAction
    {
        public void ChoiceActionByCustomer(string answer, RoyalCarContext json, Consultant consultant, RentManagement rentManager, string filename, Customer customer)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("You can choose car by number");
                    if (answer == "1")
                    {
                        List<Car> availableCars = consultant.GetAvailableCar(json);
                        Writer.PrintArray(availableCars);
                        string index = Console.ReadLine();
                        rentManager.CheckOccupationOfCarAndSetConnectionWithCustomer(availableCars[Convert.ToInt32(index) - 1], customer);
                        JsonToArrayObject.SerializeArray(json, filename);
                        Console.WriteLine("You occupied a car! Have a good day!");
                    }
                    else if (answer == "2")
                    {
                        List<Car> occupiedCarByCustomer = consultant.GetOccupiedCarsByCustomer(json, customer);
                        Writer.PrintArray(occupiedCarByCustomer);
                        string index = Console.ReadLine();
                        rentManager.CheckRefundOfCarAndSetConnectionWithCustomer(occupiedCarByCustomer[Convert.ToInt32(index) - 1], customer);
                        JsonToArrayObject.SerializeArray(json, filename);
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
