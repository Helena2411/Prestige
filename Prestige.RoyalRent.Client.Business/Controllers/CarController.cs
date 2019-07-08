using System;
using System.Collections.Generic;
using Prestige.RoyalRent.Common;
using AutoMapper;


namespace Prestige.RoyalRent.Client.Business.Controllers
{
    public class CarController
    {
        private readonly RoyalCarContext _context;

        public delegate List<Car> GetCars(Customer<string> customer);

        public CarController()
        {
            _context = RoyalCarContext.Context;
        }

        public List<Car> GetAvailableCars(Customer<string> customer)
        {
            List<Car> availableCars = new List<Car>();
            bool isEmpty = true;
            for (int i = 0; i < _context.Cars.Count; i++)
            {
                if (!_context.Cars[i].CustomerId.Equals(customer.Id))
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

        public List<Car> GetOccupiedCarsByCustomer(Customer<string> customer)
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

        public void OccupyOfCarByCustomer(Car car, Customer<string> customer)
        {
            car.CustomerId = customer.Id;

            _context.SaveChanges();
        }

        public void RefundOfCarByCustomer(Car car)
        {
            car.CustomerId = "";

            _context.SaveChanges();
        }
    }
}