using System;

namespace TravelCard.Domain
{
    public class InvalidZoneException : Exception
    {
        public InvalidZoneException()
        {

        }
        public InvalidZoneException(string message) : base(message)
        {

        }

        public InvalidZoneException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
