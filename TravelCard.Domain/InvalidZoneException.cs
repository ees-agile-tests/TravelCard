using System;

namespace TravelCard.Domain
{
    public class InvalidZoneException : InvalidOperationException
    {
        
        public InvalidZoneException() { }

        public InvalidZoneException(string message) : base(message) { }

    }
}
