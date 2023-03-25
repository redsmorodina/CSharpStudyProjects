using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2PersonProceed.Exceptions
{
    internal class WrongEmilFormatException : Exception
    {
        public WrongEmilFormatException() : base() { }
        public WrongEmilFormatException(string message) : base(message) { }
        public WrongEmilFormatException(string message, Exception inner) : base(message, inner) { }
    }
}
