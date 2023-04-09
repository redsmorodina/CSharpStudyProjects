using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2PersonProceed.Exceptions
{
    internal class WrongEmailFormatException : Exception
    {
        public WrongEmailFormatException() : base() { }
        public WrongEmailFormatException(string message) : base(message) { }
        public WrongEmailFormatException(string message, Exception inner) : base(message, inner) { }
    }
}
