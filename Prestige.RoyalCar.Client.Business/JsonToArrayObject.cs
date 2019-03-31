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

        public static void SerializeArray(ObjectJson objectJson, string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                var json = JsonConvert.SerializeObject(objectJson);
                file.WriteLine(json);
            }
        }

        public static ObjectJson DeserializeArray(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                var json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<ObjectJson>(json);
            }
        }
    }
}
