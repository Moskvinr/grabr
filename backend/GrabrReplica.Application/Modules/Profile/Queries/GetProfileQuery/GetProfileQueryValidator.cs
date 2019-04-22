using FluentValidation;

namespace GrabrReplica.Application.Modules.Profile.Queries.GetProfileQuery
{
    public class GetProfileQueryValidator : AbstractValidator<GetProfileQuery>
    {
        public GetProfileQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
        }
    }
}