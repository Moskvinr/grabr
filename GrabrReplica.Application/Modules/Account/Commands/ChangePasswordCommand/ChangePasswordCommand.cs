using MediatR;

namespace GrabrReplica.Application.Modules.Account.Commands.ChangePasswordCommand
{
    public class ChangePasswordCommand : IRequest
    {
        public string UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}