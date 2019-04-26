using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Order.Commands.CancelDeliverOderCommand;
using GrabrReplica.Application.Modules.Order.Commands.ConfirmOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.CreateOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.DeclineOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.DeliverOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.UpdateOrderCommand;
using GrabrReplica.Application.Modules.Order.Queries.GetAllOrdersQuery;
using GrabrReplica.Application.Modules.Order.Queries.GetOrderQuery;
using GrabrReplica.Application.Modules.Order.Queries.GetUserOrdersQuery;
using GrabrReplica.Common;
using GrabrReplica.Web.Extensions;
using GrabrReplica.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    [JwtAuthorize(Roles = UserRoleNames.User + "," + UserRoleNames.Admin)]
    public class OrderController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var id = HttpContext.GetUserId();
            command.CreatorId = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOrderCommand command)
        {
            command.OrderId = id;
            command.CreatorId = HttpContext.GetUserId();
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteOrderCommand();
            command.OrderId = id;
            command.CreatorId = HttpContext.GetUserId();
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = UserRoleNames.Admin)]
        public async Task<IActionResult> Confirm(int id)
        {
            return Ok(await Mediator.Send(new ConfirmOrderCommand {OrderId = id}));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = UserRoleNames.Admin)]
        public async Task<IActionResult> Decline(int id)
        {
            return Ok(await Mediator.Send(new DeclineOrderCommand {OrderId = id}));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DeliverOrder(int id)
        {
            await Mediator.Send(new DeliverOrderCommand {OrderId = id, UserId = HttpContext.GetUserId()});
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllOrdersQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderQuery() {OrderId = id}));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserOrders(string id)
        {
            return Ok(await Mediator.Send(new GetUserOrdersQuery() { UserId = id}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelDeliver(int id)
        {
            await Mediator.Send(new CancelDeliverOderCommand() {OrderId = id, UserId = HttpContext.GetUserId()});
            return NoContent();
        }
        
    }
}