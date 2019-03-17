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

namespace Prestige.RoyalCar
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filename = ConfigurationManager.AppSettings.Get("FileName");
            List<Car> cars = JsonToArrayObject.DeserializeArray(filename);

            Console.WriteLine("Hi! What is your name?");
            string name = Console.ReadLine();
            Customer customer = new Customer(name);

            Writer.PrintArray(cars);
            Console.WriteLine("\n" + customer.Name + ", you can choose, that you want to do: 1.occupy car or 2. retrieve car");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                Console.WriteLine("You can choose car by number (true acess for occupy)");
                string index = Console.ReadLine();
                cars = customer.OccupyCar(cars, Convert.ToInt32(index) - 1);
                JsonToArrayObject.SerializeArray(cars, filename);
            }
            else if (answer == "2")
            {
                Console.WriteLine("You can choose car by number (true access for occupy)");
                string index = Console.ReadLine();
                cars = customer.RetrieveCar(cars, Convert.ToInt32(index) - 1);
                JsonToArrayObject.SerializeArray(cars, filename);
            }
            else Console.WriteLine("Incorrect! Bye!"); 

            Console.ReadLine();
        }
    }
}
