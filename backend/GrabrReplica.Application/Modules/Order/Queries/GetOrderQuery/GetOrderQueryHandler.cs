using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using GrabrReplica.Application.Modules.Order.Models;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Queries.GetOrderQuery
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .Include(x=>x.OrderBy)
                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            return _mapper.Map<OrderDto>(order);
        }
    }
}