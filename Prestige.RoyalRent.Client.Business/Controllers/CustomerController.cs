namespace Prestige.RoyalRent.Client.Business.Controllers
{
    public class CustomerController
    {
        private readonly RoyalCarContext _context;

        public CustomerController()
        {
            _context = RoyalCarContext.Context;
        }

        public Customer<string> AddNewCustomerOrGetExisting(string email, string name)
        {
            Customer<string> customer;
            // TODO convert to LINQ
            for (int i = 0; i < _context.Customers.Count; i++)
            {
                if (email == _context.Customers[i].Email)
                {
                    customer = _context.Customers[i];
                    return customer; // TODO use automapper
                }
            }
            customer = new Customer<string>(name, email);
            _context.Customers.Add(customer);
            return customer; // TODO use automapper
        }
    }
}
