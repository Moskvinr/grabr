using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.DeliverOrderCommand
{
    public class DeliverOrderCommandHandler : IRequestHandler<DeliverOrderCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeliverOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);
            
            order.SetDeliver(request.UserId);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}