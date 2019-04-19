using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.DeclineOrderCommand
{
    public class DeclineOrderCommandValidator : AbstractValidator<DeclineOrderCommand>
    {
        public DeclineOrderCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
            RuleFor(x => x.OrderId).MustAsync(async (id, cancellation) =>
                {
                    var exist = await dbContext.Orders.AnyAsync(e => e.Id == id);
                    return !exist;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
                .WithMessage($"Order not exist");
        }
    }
}