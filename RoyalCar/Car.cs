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
        [JsonProperty(PropertyName ="Brand")]
        private string brand { get; set;}
        [JsonProperty(PropertyName = "Model")]
        private string model { get; set; }
        [JsonProperty(PropertyName = "Carcase")]
        private string carcase { get; set;}
        [JsonProperty(PropertyName = "Motor")]
        private string motor { get; set; }
        [JsonProperty(PropertyName = "Color")]
        private string color { get; set; }
        [JsonProperty(PropertyName = "Occupancy")]
        private bool occupancy { get; set; }
        public Car(string brand, string model, string carcase, string motor, string color) {
            this.brand = brand;
            this.model = model;
            this.carcase = carcase;
            this.motor = motor;
            this.color = color; 
        }
        public void setBrand(string brand)
        {
            this.brand=brand;
        }
        public string getBrand() {
            return brand;
        }
        public void setModel(string model)
        {
            this.model = model;
        }
        public string getModel()
        {
            return model;
        }
        public void setCarcase(string carcase)
        {
            this.carcase = carcase;
        }
        public string getCarcase()
        {
            return carcase;
        }
        public void setMotor(string motor)
        {
            this.motor = motor;
        }
        public string getMotor()
        {
            return motor;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public string getColor()
        {
            return brand;
        }
        public void setOccypancy(bool occupancy)
        {
            this.occupancy = occupancy;
        }
        public bool getOccypancy()
        {
            return occupancy;
        }
        public override string ToString()
        {
            return brand + " " + model + " " + carcase + " " + motor + " " + color + "  [" + Convert.ToString(occupancy) + "] ";
        }
    }
}
