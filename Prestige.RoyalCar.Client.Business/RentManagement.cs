using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class RentManagement
    {
        public void CheckOccupationOfCarAndSetConnectionWithCustomer(RoyalCarContext json, int index, Customer customer)
        {
            if (json.Cars[index].CustomerId != "")
            {
                throw new OccupyException("This car is already occupied");
            }
            json.Cars[index].CustomerId = customer.Id;
        }

        public void CheckRefundOfCarAndSetConnectionWithCustomer(RoyalCarContext json, int index, Customer customer)
        {
            if (json.Cars[index].CustomerId == "")
            {
                throw new OccupyException("This car is already retrieved ");
            }
            json.Cars[index].CustomerId = "";
        }
    }
}
