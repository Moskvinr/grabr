using GrabrReplica.Infrastructure.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GrabrReplica.Infrastructure.Notifications
{
    public abstract class INotificationService
    {
        protected readonly EmailSettings _emailSettings;
        protected readonly IEmailMessageGenerator _emailMessageGenerator;

        public INotificationService(EmailSettings emailSettings, IEmailMessageGenerator emailMessageGenerator)
        {
            _emailMessageGenerator = emailMessageGenerator;
            _emailSettings = emailSettings;
        }

        protected async Task Send(Message message)
        {
            var smtpClient = ConfigureSmtp();
            using (var emailMessage = new MailMessage(_emailSettings.EmailFrom, message.To)
            {
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsHtmlBody
            })
            {
                await smtpClient.SendMailAsync(emailMessage);
            }
        }

        private SmtpClient ConfigureSmtp()
        {
            return new SmtpClient
            {
                Host = _emailSettings.PrimaryDomain,
                Port = _emailSettings.PrimaryPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailSettings.EmailFrom, _emailSettings.PasswordFrom)
            };
        }

        public abstract Task SendConfirmationLinkAsync(string email, string id, string confirmLink);

        public abstract Task SendForgotPasswordLinkAsync(string email, string id, string confirmLink);

        public abstract Task SendResetPasswordLinkAsync(string email, string id, string confirmLink);
    }
}
