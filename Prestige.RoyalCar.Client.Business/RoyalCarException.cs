using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class RoyalCarException : Exception
    {
        public RoyalCarException() { }

        public RoyalCarException(string message) : base(message) { }

        public RoyalCarException(string message, Exception inner) : base(message, inner) { }
    }
}
