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

            CustomerAction customerAction = new CustomerAction();
            customerAction.ChoiceActionByCustomer(answer, json, consultant, rentManager, filename, customer);
        }
    }
}
