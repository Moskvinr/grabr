using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrabrReplica.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public string LifeTime { get; set; }
    }
}
