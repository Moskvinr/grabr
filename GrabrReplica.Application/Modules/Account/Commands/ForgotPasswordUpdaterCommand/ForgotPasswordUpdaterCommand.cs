using MediatR;

namespace GrabrReplica.Application.Modules.Account.Commands.ForgotPasswordUpdaterCommand
{
    public class ForgotPasswordUpdaterCommand : IRequest
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}