using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCore.Models.Security
{
    public class AuthorizationPolicy
    {

        public string PolicyName { get; set; }


        public string ClaimName { get; set; }


        public IList<string> ClaimValues { get; set; }
    }
}
