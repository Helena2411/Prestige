﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar.Client.Business
{
    public class RentManagement
    {
        public void CheckOccupyCar(Dictionary<String, String> databaseOfOrders, List<Car> cars, String idCustomer, int index)
        {
            if (cars[index].IsOccupied)
            {
                databaseOfOrders.Add(cars[index].Id, idCustomer);
                cars[index].IsOccupied = false;
            }
            else
            {
                throw new OccupyException("This car is already occupied ");
            }
        }

        public void CheckRetrieveCar(Dictionary<String, String> dictionary, List<Car> cars, String idCustomer, int index)
        {
            if (cars[index].IsOccupied)
            {
                throw new OccupyException("This car is already retrieved ");
            }
            else
            {
                dictionary.Remove(cars[index].Id);
                cars[index].IsOccupied = true;
            }
        }
    }
}
