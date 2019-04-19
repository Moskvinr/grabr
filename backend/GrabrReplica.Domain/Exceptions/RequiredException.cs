using System;

namespace GrabrReplica.Domain.Exceptions
{
    public class RequiredException : Exception
    {
        public RequiredException(string name, object key, string message) : base(
            message: $"{name} required not to be null"
        )
        {
        }
    }
}