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
using Prestige.RoyalCar.Client.Business;

namespace Prestige.RoyalCar
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = ConfigurationManager.AppSettings.Get("FileName");
            ObjectJson json = JsonToArrayObject.DeserializeArray(filename);

            Console.WriteLine("Hi! What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("What is your email?");
            string email = Console.ReadLine();

            Customer customer = RecordCustomer.checkCustomer(json, email, name);

            RentManagement rentManager = new RentManagement();
            Writer.PrintAvailableCar(json, customer);
            Console.WriteLine($"{customer.Name}, you can choose, that you want to do: 1.occupy car or 2. retrieve car");
            string answer = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("You can choose car by number (true - available for occupation)");
                    if (answer == "1")
                    {
                        string index = Console.ReadLine();
                        rentManager.CheckOccupyCar(json, Convert.ToInt32(index) - 1, customer);
                        JsonToArrayObject.SerializeArray(json, filename);
                        Console.WriteLine("You occupied a car! Have a good day!");
                    }
                    else if (answer == "2")
                    {
                        string index = Console.ReadLine();
                        rentManager.CheckRetrieveCar(json, Convert.ToInt32(index) - 1, customer);
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
                catch (OccupyException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
