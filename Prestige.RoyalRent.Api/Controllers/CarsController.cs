using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly PrestigeContext db;

        // GET api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            return db.Cars.ToList();
        }
    }
}