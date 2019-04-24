using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.ConfirmDeliveryOrderCommand
{
    public class ConfirmDeliveryOrderCommand : IRequest
    {
        public string UserId { get; set; }
        public int OrderId { get; set; }
    }
}