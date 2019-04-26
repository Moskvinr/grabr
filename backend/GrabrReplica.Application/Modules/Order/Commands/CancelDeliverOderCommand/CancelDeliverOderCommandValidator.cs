using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.CancelDeliverOderCommand
{
    public class CancelDeliverOderCommandValidator : AbstractValidator<CancelDeliverOderCommand>
    {
        public CancelDeliverOderCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull();
            RuleFor(x => x.OrderId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == e.UserId, cancellation);
                    if (user == null)
                    {
                        return false;
                    }

                    var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == e.OrderId, cancellation);
                    if (order?.OrderByUserId == user.Id)
                    {
                        return false;
                    }
                    
                    return order?.DeliveryManUserId != null;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString());
        }
    }
}