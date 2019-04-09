using GrabrReplica.Common.EmailMessages;
using GrabrReplica.Infrastructure.Notifications.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Infrastructure.Notifications
{
    public class EmailMessageGenerator : IEmailMessageGenerator
    {
        public override Message GenerateConfirmationMessage(string email, string id, string confirmLink)
        {
            var emailBody = $"{EmailMessageConstants.ConfimrationEmailBody} <a href=?userId={id}&code={confirmLink}>Ссылка</a>";
            return base.GenerateMessage(email, EmailMessageConstants.ConfimrationEmailSubject, emailBody);
        }

        public override Message GenerateForgotPasswordMessage(string email, string id, string confirmLink)
        {
            var emailBody = $"{EmailMessageConstants.ForgotPasswordEmailBody} <a href=?userId={id}&code={confirmLink}>Ссылка</a>";
            return base.GenerateMessage(email, EmailMessageConstants.ForgotPasswordEmailSubject, emailBody);
        }

        public override Message GenerateResetPasswordMessage(string email, string id, string confirmLink)
        {
            var emailBody = $"{EmailMessageConstants.ResetPasswordEmailBody} <a href=?userId={id}&code={confirmLink}>Ссылка</a>";
            return base.GenerateMessage(email, EmailMessageConstants.ResetPasswordEmailSubject, emailBody);
        }
    }
}
