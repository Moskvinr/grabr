using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Account.Commands.ChangePasswordCommand;
using GrabrReplica.Application.Modules.Account.Commands.ConfirmEmailCommand;
using GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordCommand;
using GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpdaterCommand;
using GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand;
using GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand;
using GrabrReplica.Application.Modules.Account.Queries.ConfirmEmailQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountCommand command)
        {
            return await SendMediatorRequest(command);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            return await SendMediatorRequest(command);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailQuery query)
        {
            return await SendMediatorRequest(query);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            return await SendMediatorRequest(command);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        {
            return await SendMediatorRequest(command);
        }

        [HttpPatch]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordUpdaterCommand command)
        {
            return await SendMediatorRequest(command);
        }

        private async Task<IActionResult> SendMediatorRequest(IRequest request)
        {
            await Mediator.Send(request);
            return NoContent();
        }
    }
}