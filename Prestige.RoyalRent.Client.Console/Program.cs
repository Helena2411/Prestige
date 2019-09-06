
using Prestige.RoyalRent.Client.Business.Models;

namespace Prestige.RoyalRent.Client.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine("Hi! What is your name?");
            //string name = System.Console.ReadLine();
            //System.Console.WriteLine("What is your email?");
            //string email = System.Console.ReadLine();
            //System.Console.WriteLine("What is your password?");
            //string password = System.Console.ReadLine();
            var user = new Customer()
            {
                Email = "lenka_bokshic@mail.ru",
                Name = "helena",
                Password = "lenka999"
            };
            var customerAction = new CustomerAction();
            _ = customerAction.ChoiceActionByCustomerAsync(user);
        }
    }
}
