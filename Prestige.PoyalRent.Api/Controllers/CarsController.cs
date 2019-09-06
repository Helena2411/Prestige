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
    public class CarsController : ControllerBase
    {
        private readonly PrestigeContext _db;
        private readonly IMapper _mapper;

        public CarsController(PrestigeContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        //GET api/cars
        [HttpGet("allCars")]
        public List<Car> Get()
        {
            return _mapper.Map<List<Car>>(_db.Cars.ToList());
        }

        //GET api/cars/5
        [HttpGet]
        public List<Car> Get([FromQuery]int customerId, [FromQuery]bool book)
        {
            List<Car> cars;
            if (book)
            {
                cars = _mapper.Map<List<Car>>(_db.Cars.Where(x => x.CustomerId == -1).ToList());
            }
            else
            {
                cars = _mapper.Map<List<Car>>(_db.Cars.Where(x => x.CustomerId == customerId).ToList());
            }

            if (cars == null)
                return new List<Car>();
            return cars;
        }

        [HttpPost]
        public async Task<Car> Post([FromBody] Car car)
        {
            _db.Cars.Add(_mapper.Map<Client.Business.Models.Car>(car));
            await _db.SaveChangesAsync();
            return _mapper.Map<Car>(car);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromQuery]int carId, [FromQuery]int customerId)
        {
            var car = _db.Cars.FirstOrDefault(x => x.Id == carId);
            if (car != null)
            {
                car.CustomerId = customerId;
                _db.Cars.Update(_mapper.Map<Client.Business.Models.Car>(car));
                await _db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpPut("{carId}")]
        public async Task<ActionResult> Refund(int carId)
        {
            var car = _db.Cars.FirstOrDefault(x => x.Id == carId);
            if (car != null)
            {
                car.CustomerId = -1;
                _db.Cars.Update(_mapper.Map<Client.Business.Models.Car>(car));
                await _db.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}