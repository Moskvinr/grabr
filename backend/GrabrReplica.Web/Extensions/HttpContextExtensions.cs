using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace GrabrReplica.Web.Extensions
{
    public static class HttpContextUserExtensions
    {
        public static string GetUserId(this Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            return httpContext.User.Claims.FirstOrDefault(e => e.Type == "UserId")?.Value;
        }
    }
}