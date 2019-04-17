using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Infrastructure.Notifications.Models
{
    public class EmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string EmailFrom { get; set; }
        public string PasswordFrom { get; set; }

    }
}
