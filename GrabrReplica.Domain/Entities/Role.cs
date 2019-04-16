using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace GrabrReplica.Domain.Entities
{
    public class Role : IdentityRole
    {
        public Role(string name)
        {
            this.Name = name;
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        protected Role()
        {
        }
    }
}