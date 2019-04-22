using GrabrReplica.Domain.Enums;

namespace GrabrReplica.Application.Modules.Order.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrderByUserId { get; set; }
        public OrderByDto OrderBy { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductLink { get; set; }
        public decimal FinalPrice { get; set; }
        public decimal Reward { get; set; }
        public int Count { get; set; }
        
        public DeliveryStatus DeliveryStatus { get; set; }
    }

    public class OrderByDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}