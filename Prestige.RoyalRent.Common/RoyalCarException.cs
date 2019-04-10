using System;

namespace Prestige.RoyalCar.Common
{
    public class RoyalCarException : Exception
    {
        public RoyalCarException() { }

        public RoyalCarException(string message) : base(message) { }

        public RoyalCarException(string message, Exception inner) : base(message, inner) { }
    }
}
