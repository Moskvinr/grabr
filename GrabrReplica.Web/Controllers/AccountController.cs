using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Account.Commands.ChangePasswordCommand;
using GrabrReplica.Application.Modules.Account.Commands.ConfirmEmailCommand;
using GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordCommand;
using GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpaderCommand;
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
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterAccountCommand command)
        {
            return await SendMediatorRequst(command);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        {
            return await SendMediatorRequst(command);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailQuery query)
        {
            return await SendMediatorRequst(query);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
        {
            return await SendMediatorRequst(command);
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand command)
        {
            return await SendMediatorRequst(command);
        }

        [HttpPatch]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordUpaderCommand command)
        {
            return await SendMediatorRequst(command);
        }

        private async Task<IActionResult> SendMediatorRequst(IRequest request)
        {
            await _mediator.Send(request);
            return NoContent();
        }
    }
}