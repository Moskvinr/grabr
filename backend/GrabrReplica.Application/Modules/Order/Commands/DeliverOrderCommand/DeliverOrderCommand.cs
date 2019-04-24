using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.DeliverOrderCommand
{
    public class DeliverOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}