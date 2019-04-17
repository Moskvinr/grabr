using MediatR;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordCommand
{
    public class ForgotPasswordCommand : IRequest
    {
        public string Email { get; set; }
    }
}