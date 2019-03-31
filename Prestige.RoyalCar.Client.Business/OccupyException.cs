using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalRent.Client.Business
{
    public class OccupyException : Exception
    {
        public OccupyException() { }

        public OccupyException(string message) : base(message) { }

        public OccupyException(string message, Exception inner) : base(message, inner) { }
    }
}
