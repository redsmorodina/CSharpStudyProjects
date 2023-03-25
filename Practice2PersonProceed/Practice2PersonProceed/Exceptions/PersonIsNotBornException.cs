using System;

namespace Practice2PersonProceed.Exeptions
{
    internal class PersonIsNotBornException : Exception
    {
        public PersonIsNotBornException() : base() { }
        public PersonIsNotBornException(string message) : base(message) { }
        public PersonIsNotBornException(string message, Exception inner) : base(message, inner) { }
    }
}
