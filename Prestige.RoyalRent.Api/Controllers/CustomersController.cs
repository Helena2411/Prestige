using System.Collections.Generic;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly RoyalCarContext _context;

        public CustomersController()
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

        // GET api/customers/5
        [HttpGet("email")]
        public ActionResult<Customer<string>> Get(string email)
        {
            Customer<string> customer;
            for (int i = 0; i < _context.Customers.Count; i++)
            {
                if (email == _context.Customers[i].Email)
                {
                    customer = _context.Customers[i];
                    return customer;
                }
            }
            return BadRequest();
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer<string>>> Get()
        {
            return _context.Customers.ToArray();
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post(string email, string name)
        {
            Customer<string> customer;
            if (email == null || name == null)
            {
                return BadRequest();
            }

            customer = new Customer<string>(name, email);
            _context.Customers.Add(customer);
            return Ok(customer);
        }
    }
}