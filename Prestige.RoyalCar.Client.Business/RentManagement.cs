using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class RentManagement
    {
        public void CheckOccupationOfCarAndSetConnectionWithCustomer(Car car, Customer customer)
        {
            if (car.CustomerId != "")
            {
                throw new OccupyException("This car is already occupied");
            }
            car.CustomerId = customer.Id;
        }

        public void CheckRefundOfCarAndSetConnectionWithCustomer(Car car, Customer customer)
        {
            if (car.CustomerId == "")
            {
                throw new OccupyException("This car is already retrieved ");
            }
            car.CustomerId = "";
        }
    }
}
