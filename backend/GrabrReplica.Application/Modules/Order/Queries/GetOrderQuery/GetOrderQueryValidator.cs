using FluentValidation;

namespace GrabrReplica.Application.Modules.Order.Queries.GetOrderQuery
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator()
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}