using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GrabrReplica.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        
        public virtual ICollection<UserRole> UserRoles { get; set; }
        
        public virtual ICollection<Order> UserOrders { get; set; }
        public virtual ICollection<Order> OrdersDelivered { get; set; }
    }
}
