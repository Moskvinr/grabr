using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Exceptions
{
    public class EntityExistsException : Exception
    {
        public EntityExistsException(string name, object key, string message)
            : base($"Creation of entity \"{name}\" ({key}) failed. {message}")
        {
        }
    }
}
