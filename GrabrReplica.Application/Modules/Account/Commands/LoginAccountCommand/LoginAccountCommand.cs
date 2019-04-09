using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand
{
    public class LoginAccountCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
