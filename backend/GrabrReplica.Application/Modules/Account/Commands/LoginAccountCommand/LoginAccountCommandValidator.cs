using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using GrabrReplica.Application.Exceptions;
using GrabrReplica.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    public class LoginAccountCommandValidator : AbstractValidator<LoginAccountCommand>
    {
        public LoginAccountCommandValidator(UserManager<User> userManager)
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    var user = await userManager.FindByEmailAsync(e.Email);
                    if (user == null)
                    {
                        throw new EntityNotExistsException("user", e.Email, "user with this email not exist");
                    }
                    return await userManager.CheckPasswordAsync(user, e.Password);
                })
                .WithMessage("Uncorrect password")
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString());
        }
    }
}