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
            Dictionary<String, String> dictionary = new Dictionary<String, String>();
            string filename = ConfigurationManager.AppSettings.Get("FileName");
            List<Car> cars = JsonToArrayObject.DeserializeArray(filename);

            Console.WriteLine("Hi! What is your name?");
            string name = Console.ReadLine();
            Customer customer = new Customer(name);
            RentManager rentManager = new RentManager();

            Writer.PrintArray(cars);
            Console.WriteLine($"{customer.Name}, you can choose, that you want to do: 1.occupy car or 2. retrieve car");
            string answer = Console.ReadLine();

            while (true)
            {
                try
                {
                    Console.WriteLine("You can choose car by number (true access for occupy)");
                    if (answer == "1")
                    {
                        string index = Console.ReadLine();
                        rentManager.CheckOccupyCar(dictionary, cars, customer.IdOfCustomer, Convert.ToInt32(index) - 1);
                        JsonToArrayObject.SerializeArray(cars, filename);
                        Console.WriteLine("You occupied a car! Have a good day!");
                    }
                    else if (answer == "2")
                    {
                        string index = Console.ReadLine();
                        rentManager.CheckRetrieveCar(dictionary, cars, customer.IdOfCustomer, Convert.ToInt32(index) - 1);
                        JsonToArrayObject.SerializeArray(cars, filename);
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
