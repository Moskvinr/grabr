using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Application.Modules.Order.Models;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Queries.GetUserOrdersQuery
{
    public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, List<OrderDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserOrdersQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Orders
                .Include(o=>o.OrderBy)
                .Where(x => x.OrderByUserId == request.UserId)
                .Select(x => _mapper.Map<OrderDto>(x))
                .ToListAsync(cancellationToken);
        }
    }
}