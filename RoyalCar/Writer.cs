using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar
{
    class Writer
    {
        public static void printLine(String message)
        {
            Console.WriteLine(message);
        }
        public static void printArray(List<Car> cars) {
            for (int i = 0; i < cars.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + cars[i].ToString());
            }
        }
    }
}
