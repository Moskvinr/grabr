using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == e.OrderId);
                    if (order == null)
                        return false;
                    return order.OrderByUserId == e.CreatorId;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString());
        }
    }
}