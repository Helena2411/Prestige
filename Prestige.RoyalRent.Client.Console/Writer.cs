﻿using System.Collections.Generic;

namespace Prestige.RoyalRent.Client.Console
{
    class Writer
    {
        public static void PrintArray(List<RoyalCar.Common.Models.Car> cars)
        {
            for (int i = 0; i < cars.Count; i++)
            {
                System.Console.WriteLine($"{i+1}. {cars[i]}");
            }
        }
    }
}