using System.IO;
using Newtonsoft.Json;

namespace Prestige.RoyalRent.Client.Business
{
    internal class JsonToArrayObject
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
