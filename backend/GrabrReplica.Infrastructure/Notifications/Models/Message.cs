using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Infrastructure.Notifications.Models
{
    public class Message
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHtmlBody { get; set; }
    }
}
