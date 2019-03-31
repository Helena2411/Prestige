using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar.Client.Business
{
    public class RentManagement
    {
        public void CheckOccupyCar(ObjectJson json, int index, Customer customer)
        {
            if (!json.Cars[index].IsOccupied)
            {
                throw new OccupyException("This car is already occupied ");
            }
            json.Cars[index].UserId = customer.Id;
            json.Cars[index].IsOccupied = false;
           }

        public void CheckRetrieveCar(ObjectJson json, int index, Customer customer)
        {
            if (json.Cars[index].IsOccupied)
            {
                throw new OccupyException("This car is already retrieved ");
            }
            json.Cars[index].UserId = "";
            json.Cars[index].IsOccupied = true;
        }
    }
}
