using System.Data;
using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Commands.ConfirmEmailCommand
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}