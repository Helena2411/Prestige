using System;

namespace Prestige.RoyalRent.Common
{
    public class RoyalRentException : Exception
    {
        public RoyalRentException() { }

        public RoyalRentException(string message1) : base(message1) { }

        public RoyalRentException(string message1, Exception inner) : base(message1, inner) { }
    }
}
