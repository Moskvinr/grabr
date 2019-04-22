using System.Collections.Generic;
using GrabrReplica.Application.Modules.Order.Models;
using MediatR;

namespace GrabrReplica.Application.Modules.Order.Queries.GetUserOrdersQuery
{
    public class GetUserOrdersQuery : IRequest<List<OrderDto>>
    {
        public string UserId { get; set; }
    }
}