using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.DeclineOrderCommand
{
    public class DeclineOrderCommandHandler : IRequestHandler<DeclineOrderCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeclineOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(DeclineOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(e => e.Id == request.OrderId,
                cancellationToken: cancellationToken);
            
            order.DeclineOrder();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}