using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.Password).EmailAddress().NotEmpty().NotNull();
        }
    }
}
