using MediatR;

namespace GrabrReplica.Application.Modules.Account.Queries.ConfirmEmailQuery
{
    public class ConfirmEmailQuery : IRequest
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}