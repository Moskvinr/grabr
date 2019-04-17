using MediatR;

namespace GrabrReplica.Application.Modules.Account.Commands.ConfirmEmailCommand
{
    public class ConfirmEmailCommand : IRequest
    {
        public string Email { get; set; }
    }
}