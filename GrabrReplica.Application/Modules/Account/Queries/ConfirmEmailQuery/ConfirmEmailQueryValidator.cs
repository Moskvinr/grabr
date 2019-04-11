using FluentValidation;

namespace GrabrReplica.Application.Modules.Account.Queries.ConfirmEmailQuery
{
    public class ConfirmEmailQueryValidator : AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailQueryValidator()
        {
            RuleFor(x => x.Code).NotNull().NotEmpty();
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            
        }
    }
}