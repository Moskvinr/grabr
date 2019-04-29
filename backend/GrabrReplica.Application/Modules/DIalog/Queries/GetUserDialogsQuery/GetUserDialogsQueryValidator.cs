using System.Xml.Linq;
using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Queries.GetUserDialogsQuery
{
    public class GetUserDialogsQueryValidator : AbstractValidator<GetUserDialogsQuery>
    {
        public GetUserDialogsQueryValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().MustAsync(async (e, cancellation) =>
                {
                    return await dbContext.Users.AnyAsync(x => x.Id == e, cancellation);
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString());
        }
    }
}