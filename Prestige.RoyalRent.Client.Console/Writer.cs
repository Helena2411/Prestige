﻿using System.Collections.Generic;
using Prestige.RoyalRent.Client.Business;

namespace Prestige.RoyalRent.Client.Console
{
    class Writer
    {
        public static void PrintArray(List<Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                System.Console.WriteLine($"{i+1}. {cars[i]}");
            }
        }
    }
}
