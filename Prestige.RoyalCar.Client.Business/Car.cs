﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar.Client.Business
{
    public class Car
    {
        public string Brand { get; set; }

        public String IdOfCar { get; set; }

        public string Model { get; set; }

        public string Carcase { get; set; }

        public string Motor { get; set; }

        public string Color { get; set; }

        public bool IsOccupied { get; set; }

        public Car(string brand, string model, string carcase, string motor, string color)
        {
            Brand = brand;
            Model = model;
            Carcase = carcase;
            Motor = motor;
            Color = color;
            IdOfCar = Guid.NewGuid().ToString("N"); ;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} {Carcase} {Motor} {Color} [{IsOccupied}].";
        }
    }
}