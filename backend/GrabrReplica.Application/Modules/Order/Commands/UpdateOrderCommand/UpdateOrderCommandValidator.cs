using System.Xml.Linq;
using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(15);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.Count).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.ProductLink).NotNull().NotEmpty().MaximumLength(300);
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