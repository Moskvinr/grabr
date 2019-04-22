using System.Collections.Generic;
using GrabrReplica.Application.Modules.Order.Models;

namespace GrabrReplica.Application.Modules.Profile.Models
{
    public class ProfileDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public List<OrderDto> UserOrders { get; set; }
        public List<OrderDto> OrdersDelivered { get; set; }
    }
}