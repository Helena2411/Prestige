using System;

namespace Prestige.RoyalRent.Common
{
    public class RoyalRentException : Exception
    {
        public RoyalRentException() { }

        public RoyalRentException(string message) : base(message) { }

        public RoyalRentException(string message, Exception inner) : base(message, inner) { }
    }
}
