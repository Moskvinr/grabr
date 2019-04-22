using MediatR;

namespace GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommand : IRequest
    {
        public int OrderId { get; set; }
        public string CreatorId { get; set; }
    }
}