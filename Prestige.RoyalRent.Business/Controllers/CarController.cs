using System;
using System.Collections.Generic;
using Prestige.RoyalCar.Common;


namespace Prestige.RoyalRent.Client.Business.Controllers
{
    public class CarController
    {
        private readonly RoyalCarContext _context;

        public CarController()
        {
            _context = RoyalCarContext.Context;
        }

        public List<RoyalCar.Common.Models.Car> GetAvailableCar()
        {
            Console.WriteLine("Available cars:");
            List<Car> availableCars = new List<Car>();
            for (int i = 0; i < _context.Cars.Count; i++)
            {
                if (_context.Cars[i].CustomerId == "")
                {
                    availableCars.Add(_context.Cars[i]);
                }
            }
            return null; // TODO use automapper
        }

        public List<RoyalCar.Common.Models.Car> GetOccupiedCarsByCustomer(RoyalCar.Common.Models.Customer customer)
        {
            List<Car> occupiedCars = new List<Car>();
            Console.WriteLine("Your current cars:");
            for (int i = 0; i < _context.Cars.Count; i++)
            {
                if (customer.Id == _context.Cars[i].CustomerId)
                {
                    occupiedCars.Add(_context.Cars[i]);
                }
            }
            return null; // TODO use automapper
        }

        public void CheckOccupationOfCarAndSetConnectionWithCustomer(RoyalCar.Common.Models.Car car, RoyalCar.Common.Models.Customer customer)
        {
            if (car.CustomerId != "")
            {
                throw new RoyalCarException("This car is already occupied");
            }
            car.CustomerId = customer.Id;

            _context.SaveChanges();
        }

        public void CheckRefundOfCarAndSetConnectionWithCustomer(RoyalCar.Common.Models.Car car, RoyalCar.Common.Models.Customer customer)
        {
            if (car.CustomerId == "")
            {
                throw new RoyalCarException("This car is already retrieved ");
            }
            car.CustomerId = "";

            _context.SaveChanges();
        }
    }
}