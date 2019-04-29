using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Dialog.Commands.SendMessageCommand;
using GrabrReplica.Application.Modules.Dialog.Queries.GetDialogQuery;
using GrabrReplica.Application.Modules.Dialog.Queries.GetUserDialogsQuery;
using GrabrReplica.Common;
using GrabrReplica.Web.Extensions;
using GrabrReplica.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    [JwtAuthorize(Roles = UserRoleNames.User + "," + UserRoleNames.Admin)]
    public class DialogsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetDialogs()
        {
            return Ok(await Mediator.Send(new GetUserDialogsQuery {UserId = HttpContext.GetUserId()}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDialogId(string id)
        {
            var query = new GetDialogQuery{InterlocutorId = id, UserId = HttpContext.GetUserId()};
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(SendMessageCommand command)
        {
            command.MessageFrom = HttpContext.GetUserId();
            await Mediator.Send(command);
            return NoContent();
        }
    }
}