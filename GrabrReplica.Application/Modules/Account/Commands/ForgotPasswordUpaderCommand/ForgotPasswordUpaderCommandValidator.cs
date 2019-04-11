using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpaderCommand
{
    public class ForgotPasswordUpaderCommandValidator : AbstractValidator<ForgotPasswordUpaderCommand>
    {
        public ForgotPasswordUpaderCommandValidator()
        {
            RuleFor(u => u.UserId).NotNull().NotEmpty();
            RuleFor(t => t.Token).NotNull().NotEmpty();
            RuleFor(p => p.NewPassword).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}