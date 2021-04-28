using System;

namespace TravelCard
{
    public class InvalidDebitException : Exception
    {
        public InvalidDebitException()
        {

        }

        public InvalidDebitException(string message) : base(message)
        {

        }

        public InvalidDebitException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
