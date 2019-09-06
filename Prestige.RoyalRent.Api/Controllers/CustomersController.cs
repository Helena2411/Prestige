using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PrestigeContext db;

        public CustomersController(PrestigeContext context)
        {
            db = context;
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
                return NotFound();
            return new ObjectResult(customer);
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer<string>>> Get()
        {
            return db.Customers.ToList();
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody]Customer<string> customer)
        {
            if (customer == null)
            {
                ModelState.AddModelError("", "Не указаны данные для пользователя");
                return BadRequest();
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            db.Customers.Add(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        // PUT api/customers
        [HttpPut]
        public IActionResult Put([FromBody]Customer<string> customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!db.Customers.Any(x => x.Id == customer.Id))
            {
                return NotFound();
            }

            db.Update(customer);
            db.SaveChanges();
            return Ok(customer);
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var  customer = db.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return BadRequest();
            }

            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok(customer);
        }
    }
}