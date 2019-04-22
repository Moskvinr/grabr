using GrabrReplica.Application.Modules.Profile.Models;
using MediatR;

namespace GrabrReplica.Application.Modules.Profile.Queries.GetProfileQuery
{
    public class GetProfileQuery : IRequest<ProfileDto>
    {
        public string UserId { get; set; }
    }
}