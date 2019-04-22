using System.Linq;
using System.Threading.Tasks;
using GrabrReplica.Application.Modules.Profile.Queries.GetProfileQuery;
using GrabrReplica.Common;
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
            var id = User.Claims.FirstOrDefault(e => e.Type == "UserId")?.Value;
            return Ok(await Mediator.Send(new GetProfileQuery
                {UserId = id}));
        }
    }
}