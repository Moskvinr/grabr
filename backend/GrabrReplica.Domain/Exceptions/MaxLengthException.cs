using System;

namespace GrabrReplica.Domain.Exceptions
{
    public class MaxLengthException : Exception
    {
        public MaxLengthException(string name, object key, string message) : base(
            message: $"length of {name} requires less than {message} symbols")
        {
        }
    }
}