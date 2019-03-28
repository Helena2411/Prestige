using Prestige.RoyalCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prestige.RoyalCar.Client.Business;

namespace Prestige.RoyalCar
{
    class Writer
    {
        public static void PrintArray(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine($"{i+1}. {cars[i]}");
            }
        }
    }
}
