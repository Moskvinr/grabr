using System.Threading;
using System.Threading.Tasks;
using GrabrReplica.Common;
using GrabrReplica.Domain.Entities;
using GrabrReplica.Domain.Enums;
using GrabrReplica.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.ConfirmDeliveryOrderCommand
{
    public class ConfirmDeliveryOrderCommandHandler : IRequestHandler<ConfirmDeliveryOrderCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<User> _userManager;

        public ConfirmDeliveryOrderCommandHandler(ApplicationDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ConfirmDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);

            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

            if (order.OrderByUserId == user.Id)
            {
                order.CustomerConfirm();
            }

            if (order.DeliveryManUserId == user.Id)
            {
                order.DeliverymanConfirm();
            }

            if (await _userManager.IsInRoleAsync(user, UserRoleNames.Admin))
            {
                order.CloseDelivery();
            }
            
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}