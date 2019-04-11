using MediatR;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpaderCommand
{
    public class ForgotPasswordUpaderCommand : IRequest
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}