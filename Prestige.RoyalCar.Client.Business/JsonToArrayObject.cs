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

namespace Prestige.RoyalRent.Client.Business
{
    public class JsonToArrayObject
    {
        public static void SerializeArray(RoyalCarContext objectJson, string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                var json = JsonConvert.SerializeObject(objectJson);
                file.WriteLine(json);
            }
        }

        public static RoyalCarContext DeserializeArray(string filename)
        {
            using (StreamReader file = new StreamReader(filename))
            {
                var json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<RoyalCarContext>(json);
            }
        }
    }
}
