using System;

namespace TravelCard.Domain
{
    public class InvalidDebitException : InvalidOperationException
    {

        public InvalidDebitException() { }

        public InvalidDebitException(string message) : base(message) { }

    }
}
