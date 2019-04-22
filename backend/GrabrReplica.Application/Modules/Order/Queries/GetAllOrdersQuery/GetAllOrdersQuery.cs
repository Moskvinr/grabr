using System.Collections.Generic;
using System.Linq;
using GrabrReplica.Application.Modules.Order.Models;
using MediatR;

namespace GrabrReplica.Application.Modules.Order.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQuery : IRequest<List<OrderDto>>
    {
        
    }
}