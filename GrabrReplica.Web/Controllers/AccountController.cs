using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Account.Commands.LoginAccountCommand;
using GrabrReplica.Application.Modules.Account.Commands.RegisterAccountCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator) { }

        public async Task<IActionResult> Register(RegisterAccountCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        public async Task<IActionResult> Login(LoginAccountCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}