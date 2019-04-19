using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.DeclineOrderCommand
{
    public class DeclineOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
    }
}