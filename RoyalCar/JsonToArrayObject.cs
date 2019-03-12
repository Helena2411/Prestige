using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Configuration;

namespace Prestige.RoyalCar
{
    public class JsonToArrayObject
    { 
        public static List<Car> DeserializeArray(string filename)
        {
            List<Car> cars;
            string json;
            using (StreamReader file = new StreamReader(filename))
                {
                    json = file.ReadToEnd();
                    cars = JsonConvert.DeserializeObject<List<Car>>(json);
                }
            return cars;
        }

        public static void SerializeArray(List<Car> cars, string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                string json = JsonConvert.SerializeObject(cars); 
                file.WriteLine(json);
            }
        }
    }
}
