using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class RentManagement
    {
        public void CheckOccupyCar(ObjectJson json, int index, Customer customer)
        {
            if (!json.Cars[index].IsOccupied)
            {
                throw new OccupyException("This car is already occupied");
            }
            json.Cars[index].CustomerId = customer.Id;
            json.Cars[index].IsOccupied = false;
        }

        public void CheckRetrieveCar(ObjectJson json, int index, Customer customer)
        {
            if (json.Cars[index].IsOccupied)
            {
                throw new OccupyException("This car is already retrieved ");
            }
            json.Cars[index].CustomerId = "";
            json.Cars[index].IsOccupied = true;
        }
    }
}
