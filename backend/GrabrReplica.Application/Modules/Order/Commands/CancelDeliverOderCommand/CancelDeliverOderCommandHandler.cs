using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.CancelDeliverOderCommand
{
    public class CancelDeliverOderCommandHandler : IRequestHandler<CancelDeliverOderCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public CancelDeliverOderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CancelDeliverOderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(x => x.Id == request.OrderId, cancellationToken);

            order.CancelDeliver();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}