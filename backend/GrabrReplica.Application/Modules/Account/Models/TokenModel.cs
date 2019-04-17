using System;
using System.Collections.Generic;
using System.Text;

namespace GrabrReplica.Application.Modules.Account.Models
{
    public class TokenModel
    {
        public string AccessToken { get; set; }
        public UserDataModel UserModel { get; set; }
    }
}
