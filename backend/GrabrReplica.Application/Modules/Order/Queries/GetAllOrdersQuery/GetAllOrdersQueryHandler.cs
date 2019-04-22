using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Application.Modules.Order.Models;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Queries.GetAllOrdersQuery
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request,
            CancellationToken cancellationToken)
        {
            return await _dbContext.Orders
                .Include(x => x.OrderBy)
                .Select(x => _mapper.Map<OrderDto>(x))
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}