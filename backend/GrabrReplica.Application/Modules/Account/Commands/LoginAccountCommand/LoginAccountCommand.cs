using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using GrabrReplica.Application.Modules.Account.Models;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    public class LoginAccountCommand : IRequest<TokenModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
