using System.Security.AccessControl;
using FluentValidation;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Order.Commands.ConfirmOrderCommand
{
    public class ConfirmOrderCommandValidator : AbstractValidator<ConfirmOrderCommand>
    {
        public ConfirmOrderCommandValidator(ApplicationDbContext dbContext)
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