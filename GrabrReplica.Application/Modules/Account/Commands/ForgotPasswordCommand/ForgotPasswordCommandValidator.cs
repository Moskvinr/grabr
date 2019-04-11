using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordCommand
{
    public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
        }
    }
}