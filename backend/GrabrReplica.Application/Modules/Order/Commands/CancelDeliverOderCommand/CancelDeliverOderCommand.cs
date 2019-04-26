using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.CancelDeliverOderCommand
{
    public class CancelDeliverOderCommand : IRequest
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
    }
}