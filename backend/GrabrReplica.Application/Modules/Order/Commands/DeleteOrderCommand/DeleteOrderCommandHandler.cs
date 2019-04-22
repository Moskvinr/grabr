using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Domain.Extensions;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext
                .Orders
                .FirstOrDefaultAsync(e => e.Id == request.OrderId, cancellationToken);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}