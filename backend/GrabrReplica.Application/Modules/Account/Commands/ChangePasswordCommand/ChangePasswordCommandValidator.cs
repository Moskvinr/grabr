using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Commands.ChangePasswordCommand
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(p => p.UserId).NotNull().NotEmpty();
            RuleFor(p => p.NewPassword).NotNull().NotEmpty().MinimumLength(8);
            RuleFor(p => p.CurrentPassword).NotNull().NotEmpty();
        }
    }
}