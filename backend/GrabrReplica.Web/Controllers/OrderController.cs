using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Order.Commands.ConfirmOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.CreateOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.DeclineOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.DeleteOrderCommand;
using GrabrReplica.Application.Modules.Order.Commands.UpdateOrderCommand;
using GrabrReplica.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    [Authorize(Roles = UserRoleNames.User + "," + UserRoleNames.Admin)]
    public class OrderController : BaseController
    {
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [Route("Update")]
        public async Task<IActionResult> UpdateOrder([FromQuery] int id, [FromBody] UpdateOrderCommand command)
        {
            command.OrderId = id;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Route("Delete")]
        public async Task<IActionResult> DeleteOrder([FromQuery] int id)
        {
            await Mediator.Send(new DeleteOrderCommand {OrderId = id});

            return NoContent();
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = UserRoleNames.Admin)]
        [Route("Confirm")]
        public async Task<IActionResult> ConfirmOrder(int id)
        {
            return Ok(await Mediator.Send(new ConfirmOrderCommand {OrderId = id}));
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = UserRoleNames.Admin)]
        [Route("Decline")]
        public async Task<IActionResult> DeclineOrder(int id)
        {
            return Ok(await Mediator.Send(new DeclineOrderCommand {OrderId = id}));
        }

//        [HttpGet]
//        [Route("GetAll")]
//        public async Task<IActionResult> GetAllOrders()
//        {
//        }
//
//        [HttpGet("{id}")]
//        [Route("Get")]
//        public async Task<IActionResult> GetOrder(int id)
//        {
//        }
//
//        [HttpGet("{id}")]
//        [Route("UserOrders")]
//        public async Task<IActionResult> GetUserOrders(string id)
//        {
//        }
    }
}