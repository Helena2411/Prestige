using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Prestige.RoyalCar
{
    public class JsonToArrayObject
    { 
        public static List<Car> CreateJsonArray(){
            List<Car> cars;
            string json;
            using (StreamReader file = new StreamReader("file.json"))
                {
                    json = file.ReadToEnd();
                    cars = JsonConvert.DeserializeObject<List<Car>>(json);
                }
            return cars;
        }
        public static void SerializJsonArray(List<Car> cars)
        {
            using (StreamWriter file = new StreamWriter("file.json"))
            {
                string json = JsonConvert.SerializeObject(cars); 
                file.WriteLine(json);
            }
        }
    }
}
