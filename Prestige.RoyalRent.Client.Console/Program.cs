﻿using Prestige.RoyalRent.Client.Business.Controllers;

namespace Prestige.RoyalRent.Client.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hi! What is your name?");
            string name = System.Console.ReadLine();
            System.Console.WriteLine("What is your email?");
            string email = System.Console.ReadLine();

            CustomerController customerController = new CustomerController();
            RoyalCar.Common.Models.Customer customer = customerController.AddNewCustomerOrGetExisting(email, name);

            System.Console.WriteLine($"{customer.Name}, you can choose, that you want to do: 1.occupy car or 2. retrieve car");
            string answer = System.Console.ReadLine();

            CustomerAction customerAction = new CustomerAction(new CarController());
            customerAction.ChoiceActionByCustomer(answer, customer);
        }
    }
}
