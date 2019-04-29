using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public string CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductLink { get; set; }
        public decimal Reward { get; set; }
        public int Count { get; set; }
        public string ProductImage { get; set; }
    }
}