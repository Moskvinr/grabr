using System.Xml.Linq;
using FluentValidation;

namespace GrabrReplica.Application.Modules.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(15);
            RuleFor(x => x.Description).NotNull().NotEmpty().MaximumLength(300);
            RuleFor(x => x.Count).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.ProductLink).NotNull().NotEmpty().MaximumLength(300);
        }
    }
}