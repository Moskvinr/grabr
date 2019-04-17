using GrabrReplica.Infrastructure.Configuration;
using GrabrReplica.Infrastructure.Notifications.Models;

namespace GrabrReplica.Infrastructure.Notifications
{
    public abstract class IEmailMessageGenerator
    {
        protected readonly IConfigurationHandler _configurationHandler;

        protected IEmailMessageGenerator(IConfigurationHandler configurationHandler)
        {
            _configurationHandler = configurationHandler;
        }
        
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

        protected string GenerateConfirmationLink(string urlPath, string id, string confirmLink)
        {
            return $"<a href={urlPath}?userId={id}&code={confirmLink}>Ссылка</a>";
        }

        public abstract Message GenerateConfirmationMessage(string email, string id, string confirmLink);

        public abstract Message GenerateResetPasswordMessage(string email, string id, string confirmLink);

        public abstract Message GenerateForgotPasswordMessage(string email, string id, string confirmLink);

    }
}