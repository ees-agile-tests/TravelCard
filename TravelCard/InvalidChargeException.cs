using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelCard
{
    public class InvalidChargeException : Exception
    {
        public InvalidChargeException()
        {

        }

        public InvalidChargeException(string message) : base(message)
        {

        }

        public InvalidChargeException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
