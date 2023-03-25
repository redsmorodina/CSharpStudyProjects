using System;

namespace Practice2PersonProceed.Exceptions
{
    internal class PersonIsTooOldException : Exception
    {
        public PersonIsTooOldException() : base() { }
        public PersonIsTooOldException(string message) : base(message) { }
        public PersonIsTooOldException(string message, Exception inner) : base(message, inner) { }
    }
}
