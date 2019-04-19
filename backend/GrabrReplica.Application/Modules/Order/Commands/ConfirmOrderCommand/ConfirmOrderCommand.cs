using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.ConfirmOrderCommand
{
    public class ConfirmOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
    }
}