using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Infrastructure.Notifications;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GrabrReplica.Application.Modules.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateOrderCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = GetOrder(request);
            
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }

        private Domain.Entities.Order GetOrder(CreateOrderCommand request) =>
            new Domain.Entities.Order(request.Name,
                request.Description,
                request.CreatorId,
                request.ProductPrice,
                request.ProductLink,
                request.Reward,
                request.Count,
                request.ProductImage);
    }
}