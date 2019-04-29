using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetDialogQuery
{
    public class GetDialogQueryValidator : AbstractValidator<GetDialogQuery>
    {
        public GetDialogQueryValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    return await dbContext.Users.AnyAsync(x => x.Id == e.UserId || x.Id == e.InterlocutorId,
                        cancellation);
                })
                .WithMessage(StatusCodes.Status400BadRequest.ToString());
        }
    }
}