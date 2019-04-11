using System;

namespace GrabrReplica.Application.Exceptions
{
    public class EmailNotConfirmedException : Exception
    {
        public EmailNotConfirmedException(string name, object key)
            : base($"Email of entity \"{name}\" ({key}) not confirmed. ")
        {
        }
    }
}