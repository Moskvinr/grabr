using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext
                .Orders
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

            order.UpdateOrder(request.Name, request.Description, request.ProductPrice, request.ProductLink,
                request.Reward, request.Count, request.ProductImage);

            _dbContext.Orders.Update(order);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}