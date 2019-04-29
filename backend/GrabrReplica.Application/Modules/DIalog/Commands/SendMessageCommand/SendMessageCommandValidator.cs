using System.Linq;
using FluentValidation;
using GrabrReplica.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Dialog.Commands.SendMessageCommand
{
    public class SendMessageCommandValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.MessageBody).NotNull().NotEmpty();
            RuleFor(x => x.SentTime).NotNull().NotEmpty();
            RuleFor(x => x.MessageFrom).NotNull().NotEmpty();
            RuleFor(x => x.MessageBody).NotNull().NotEmpty();
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    return await dbContext.Users.CountAsync(x => x.Id == e.MessageTo || x.Id == e.MessageFrom) > 2;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString());
        }
    }
}