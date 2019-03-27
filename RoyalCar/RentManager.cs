using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar
{
    class RentManager
    {
        public void CheckOccupyCar(Dictionary<String, String> dictionary,List <Car> cars, String idCustomer, int index)
        {
            if (cars[index].IsOccupied)
            {
                dictionary.Add(cars[index].IdOfCar, idCustomer);
                cars[index].IsOccupied = false;
            }
            else
            {
                throw new OccupyException("This car already is occupy ");
            }
        }

        public void CheckRetrieveCar(Dictionary<String, String> dictionary, List<Car> cars, String idCustomer, int index)
        {
            if (cars[index].IsOccupied)
            {
                throw new OccupyException("This car already is retrieve ");
            }
            else
            {
                dictionary.Remove(cars[index].IdOfCar);
                cars[index].IsOccupied = true;
            }
        }
    }
}
