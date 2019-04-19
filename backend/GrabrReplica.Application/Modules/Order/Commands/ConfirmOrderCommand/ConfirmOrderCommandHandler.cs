using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.ConfirmOrderCommand
{
    public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public ConfirmOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(e => e.Id == request.OrderId,
                cancellationToken: cancellationToken);
            
            order.ConfirmOrder();
            await _dbContext.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}