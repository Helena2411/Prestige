using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prestige.RoyalRent.Common
{
    public static class JsonConvertPrestige
    {
        public static T Deserialize<T>(string objectJson)
        {
            return JsonConvert.DeserializeObject<T>(objectJson);
        }
    }
}
