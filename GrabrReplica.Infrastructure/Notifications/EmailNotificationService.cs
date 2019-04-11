using GrabrReplica.Infrastructure.Notifications.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrabrReplica.Infrastructure.Notifications
{
    public class EmailNotificationService : INotificationService
    {
        public EmailNotificationService(IOptions<EmailSettings> emailSettings, IEmailMessageGenerator emailMessageGenerator) : base(emailSettings, emailMessageGenerator) { }

        public async override Task SendConfirmationLinkAsync(string email, string id, string confirmLink)
        {
            var message = _emailMessageGenerator.GenerateConfirmationMessage(email, id, confirmLink);
            await base.Send(message);
        }

        public async override Task SendForgotPasswordLinkAsync(string email, string id, string confirmLink)
        {
            var message = _emailMessageGenerator.GenerateForgotPasswordMessage(email, id, confirmLink);
            await base.Send(message);
        }

        public async override Task SendResetPasswordLinkAsync(string email, string id, string confirmLink)
        {
            var message = _emailMessageGenerator.GenerateResetPasswordMessage(email, id, confirmLink);
            await base.Send(message);
        }
    }
}
