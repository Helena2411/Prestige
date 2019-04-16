using System;
using System.Collections.Generic;
using Prestige.RoyalRent.Common;
using AutoMapper;


namespace Prestige.RoyalRent.Client.Business.Controllers
{
    public class CarController
    {
        private readonly RoyalCarContext _context;

        public CarController()
        {
            _context = RoyalCarContext.Context;
        }

        public List<Car> GetAvailableCar()
        {
            List<Car> availableCars = new List<Car>();
            bool isEmpty = true;
            for (int i = 0; i < _context.Cars.Count; i++)
            {
                if (_context.Cars[i].CustomerId == "")
                {
                    availableCars.Add(_context.Cars[i]);
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                throw new RoyalRentException("You haven't available for occupy cars! Please, choose your action again");
            }
            return availableCars; // TODO use automapper
        }

        public List<Car> GetOccupiedCarsByCustomer(Customer customer)
        {
            List<Car> occupiedCars = new List<Car>();
            bool isEmpty = true;
            for (int i = 0; i < _context.Cars.Count; i++)
            {
                if (customer.Id == _context.Cars[i].CustomerId)
                {
                    occupiedCars.Add(_context.Cars[i]);
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                throw new RoyalRentException("You haven't occupied car by youself! Please, choose your action again");
            }
            return occupiedCars; // TODO use automapper
        }

        public void CheckOccupationOfCarAndSetConnectionWithCustomer(Car car, Customer customer)
        {
            car.CustomerId = customer.Id;

            _context.SaveChanges();
        }

        public void CheckRefundOfCarAndSetConnectionWithCustomer(Car car, Customer customer)
        {
            car.CustomerId = "";

            _context.SaveChanges();
        }
    }
}