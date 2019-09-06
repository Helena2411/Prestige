using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Prestige.RoyalRent.Api.Models;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PrestigeContext _db;
        private readonly IMapper _mapper;

        public CustomersController(PrestigeContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<Customer> Get()
        {
            return _mapper.Map<List<Customer>>(_db.Customers.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();
            return new ObjectResult(customer);
        }

        [HttpPost]
        public async Task<Customer> Post([FromBody] Customer customer)
        {
            var user = _db.Customers.FirstOrDefault(x => x.Password == customer.Password);
            if (user == null)
            {
                user = new Client.Business.Models.Customer
                {
                    Name = customer.Name,
                    Email = customer.Email,
                    Password = customer.Password
                };
                _db.Customers.Add(user);
                await _db.SaveChangesAsync();
            }
            return _mapper.Map<Customer>(user);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!_db.Customers.Any(x => x.Id == customer.Id))
            {
                return NotFound();
            }

            _db.Update(customer);
            _db.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var  customer = _db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return BadRequest();
            }

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            return Ok(customer);
        }
    }
}