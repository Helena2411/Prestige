using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Prestige.RoyalRent.Client.Business
{
    public class CustomerService
    {
        public Customer AddNewCustomerOrGetExisting(RoyalCarContext json, string email, string name)
        {
            Customer customer;
            // TODO convert to LINQ
            for (int i = 0; i < json.Customers.Count; i++)
            {
                if (email == json.Customers[i].Email)
                {
                    customer = json.Customers[i];
                    return customer;
                }
            }
            customer = new Customer(name, email);
            json.Customers.Add(customer);
            return customer;
        }
    }
}
