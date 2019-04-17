using FluentValidation;
using GrabrReplica.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        public RegisterAccountCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
        }
    }
}
