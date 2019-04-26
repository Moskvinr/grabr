using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Profile.Queries.GetProfileQuery;
using GrabrReplica.Common;
using GrabrReplica.Web.Extensions;
using GrabrReplica.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Controllers
{
    [JwtAuthorize(Roles = UserRoleNames.User + "," + UserRoleNames.Admin)]
    public class ProfileController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetInfo()
        {
            return Ok(await Mediator.Send(new GetProfileQuery
                {UserId = HttpContext.GetUserId()}));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfo(string id)
        {
            return Ok(await Mediator.Send(new GetProfileQuery
                {UserId = id}));
        }
    }
}