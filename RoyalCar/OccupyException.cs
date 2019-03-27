using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prestige.RoyalCar
{
    class OccupyException : ApplicationException
    {
        public OccupyException() { }

        public OccupyException(string message) : base(message) { }
    }
}
