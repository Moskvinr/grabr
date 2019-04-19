using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequest
    {
        public int OrderId { get; set; }
    }
}