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
namespace Prestige.RoyalCar.Client.Business
{
    public class JsonToArrayObject
    {
        public static List<Car> DeserializeArray(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                var json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Car>>(json);
            }
        }

        public static void SerializeArray(List<Car> cars, string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                var json = JsonConvert.SerializeObject(cars);
                file.WriteLine(json);
            }
        }
    }
}
