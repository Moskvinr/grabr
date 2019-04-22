using GrabrReplica.Application.Modules.Order.Models;
using MediatR;

namespace GrabrReplica.Application.Modules.Order.Queries.GetOrderQuery
{
    public class GetOrderQuery : IRequest<OrderDto>
    {
        public int OrderId { get; set; }
    }
}