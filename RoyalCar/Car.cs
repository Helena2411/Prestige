using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Prestige.RoyalCar
{
    public class Car
    {
        [JsonProperty(PropertyName = "BRAND")]
        private string brand;
        public string Brand{
            get {
                return brand;
            }
            set
            {
                brand = value;
            }
        }
        [JsonProperty(PropertyName = "MODEL")]
        private string model;
        public string Model{
            get
            {
                return model;
            }
            set
            {
              model = value;
            }
        }
        [JsonProperty(PropertyName = "CARCASE")]
        private string carcase;
        public string Carcase{
            get
            {
                return carcase;
            }
            set
            {
                carcase = value;
            }
        }
        [JsonProperty(PropertyName = "MOTOR")]
        private string motor;
        public string Motor{
            get
            {
                return motor;
            }
            set
            {
                motor = value;
            }
        }
        [JsonProperty(PropertyName = "COLOR")]
        private string color;
        public string Color{
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        [JsonProperty(PropertyName = "OCCUPANCY")]
        private bool occupancy;
        public bool Occupancy{
            get
            {
                return occupancy;
            }
            set
            {
                occupancy = value;
            }
        }
        public Car(string brand, string model, string carcase, string motor, string color) {
            this.brand = brand;
            this.model = model;
            this.carcase = carcase;
            this.motor = motor;
            this.color = color; 
        }
        public override string ToString()
        {
            return brand + " " + model + " " + carcase + " " + motor + " " + color + "  [" + Convert.ToString(occupancy) + "] ";
        }
    }
}
