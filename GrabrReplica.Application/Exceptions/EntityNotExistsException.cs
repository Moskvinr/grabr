using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Exceptions
{
    class EntityNotExistsException : Exception
    {
        public EntityNotExistsException(string name, object key, string message)
               : base($"Entity \"{name}\" ({key}) not exists. {message}")
        {
        }
    }
}
