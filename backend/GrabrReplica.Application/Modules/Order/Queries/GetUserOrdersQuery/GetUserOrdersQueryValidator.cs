using FluentValidation;
using GrabrReplica.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GrabrReplica.Application.Modules.Order.Queries.GetUserOrdersQuery
{
    public class GetUserOrdersQueryValidator : AbstractValidator<GetUserOrdersQuery>
    {
        public GetUserOrdersQueryValidator(UserManager<User> _userManager)
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.UserId).MustAsync(async (u, cancellation) =>
                {
                    var user = await _userManager.FindByIdAsync(u);
                    return user != null;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
                .WithMessage("User not exist");
        }
    }
}