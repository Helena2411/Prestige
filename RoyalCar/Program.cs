using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = ConfigurationManager.AppSettings.Get("FileName");
            RoyalCarContext json = JsonToArrayObject.DeserializeArray(filename);

            Console.WriteLine("Hi! What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your email?");
            string email = Console.ReadLine();

            CustomerService customerService = new CustomerService();
            Customer customer = customerService.AddNewCustomerOrGetExisting(json, email, name);

            RentManagement rentManager = new RentManagement();
            Consultant consultant = new Consultant();
       
            Console.WriteLine($"{customer.Name}, you can choose, that you want to do: 1.occupy car or 2. retrieve car");
            string answer = Console.ReadLine();
            
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
                        rentManager.CheckOccupationOfCarAndSetConnectionWithCustomer(availableCars[Convert.ToInt32(index)-1], customer);
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
