using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpdaterCommand
{
    public class ForgotPasswordUpdaterCommandValidator : AbstractValidator<ForgotPasswordUpdaterCommand>
    {
        public ForgotPasswordUpdaterCommandValidator()
        {
            RuleFor(u => u.UserId).NotNull().NotEmpty();
            RuleFor(t => t.Token).NotNull().NotEmpty();
            RuleFor(p => p.NewPassword).NotNull().NotEmpty().MinimumLength(8);
        }
    }
}