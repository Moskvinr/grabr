using FluentValidation;
using GrabrReplica.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand
{
    public class RegisterAccountCommandValidator : AbstractValidator<RegisterAccountCommand>
    {
        public RegisterAccountCommandValidator(ApplicationDbContext dbContext)
        {
            RuleFor(x => x.Email).EmailAddress().NotEmpty().NotNull();
            RuleFor(x => x.UserName).NotEmpty().NotNull();
            RuleFor(x => x.Password).NotEmpty().NotNull();
            RuleFor(x => x).MustAsync(async (e, cancellation) =>
                {
                    var checkIfExist = await dbContext
                        .Users
                        .AnyAsync(x => x.Email == e.Email || x.UserName == e.UserName);
                    return !checkIfExist;
                })
                .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
                .WithMessage("User with this credentials already exist");
        }
    }
}