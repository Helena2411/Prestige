using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class Car
    {
        public EnumBrand Brand { get; set; }

        public string Id { get; set; }

        public EnumModel Model { get; set; }

        public EnumCarcase Carcase { get; set; }

        public string Motor { get; set; }

        public string Color { get; set; }

        public string CustomerId { get; set; }

        public Car(EnumBrand brand, EnumModel model, EnumCarcase carcase, string motor, string color)
        {
            Brand = brand;
            Model = model;
            Carcase = carcase;
            Motor = motor;
            Color = color;
            Id = Guid.NewGuid().ToString("N");
            CustomerId = "";
        }

        public override string ToString()
        {
            return $"{Brand} {Model} {Carcase} {Motor} {Color}";
        }
    }
}
