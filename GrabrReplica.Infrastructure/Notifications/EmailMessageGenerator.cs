using GrabrReplica.Infrastructure.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;
using GrabrReplica.Common.Configuration;
using GrabrReplica.Common.EmailMessagesConstants;
using GrabrReplica.Infrastructure.Configuration;

namespace GrabrReplica.Infrastructure.Notifications
{
    public class EmailMessageGenerator : IEmailMessageGenerator
    {
        public EmailMessageGenerator(IConfigurationHandler configurationHandler) : base(configurationHandler)
        {
        }

        public override Message GenerateConfirmationMessage(string email, string id, string confirmLink)
        {
            var emailBody =
                $"{EmailMessageConstants.ConfirmationEmailBody} {GenerateConfirmationLink(_configurationHandler.GetBackendPath, id, confirmLink)}";
            return base.GenerateMessage(email, EmailMessageConstants.ConfirmationEmailSubject,
                emailBody);
        }

        public override Message GenerateForgotPasswordMessage(string email, string id, string confirmLink)
        {
            var emailBody =
                $"{EmailMessageConstants.ForgotPasswordEmailBody} {GenerateConfirmationLink(_configurationHandler.GetFrontendPath, id, confirmLink)}";
            return base.GenerateMessage(email, EmailMessageConstants.ForgotPasswordEmailSubject,
                emailBody);
        }

        public override Message GenerateResetPasswordMessage(string email, string id, string confirmLink)
        {
            var emailBody =
                $"{EmailMessageConstants.ResetPasswordEmailBody} {GenerateConfirmationLink(_configurationHandler.GetFrontendPath, id, confirmLink)}";
            return base.GenerateMessage(email, EmailMessageConstants.ResetPasswordEmailSubject,
                emailBody);
        }
    }
}