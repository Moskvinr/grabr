using GrabrReplica.Infrastructure.Notifications.Models;

namespace GrabrReplica.Infrastructure
{
    public abstract class IEmailMessageGenerator
    {
        protected Message GenerateMessage(string to, string subject, string body)
        {
            return new Message
            {
                To = to,
                Body = body,
                IsHtmlBody = true,
                Subject = subject
            };
        }

        public abstract Message GenerateConfirmationMessage(string email, string id, string confirmLink);

        public abstract Message GenerateResetPasswordMessage(string email, string id, string confirmLink);

        public abstract Message GenerateForgotPasswordMessage(string email, string id, string confirmLink);

    }
}