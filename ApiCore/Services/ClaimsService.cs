using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ApiCore.Services
{
    public class ClaimsService
    {
        public string Name;
        public string SalesChannelId;

        public ClaimsService(HttpContext context)
        {
            var identity = (ClaimsIdentity)context.User.Identity;
            var claims = identity.Claims;

            Name = identity.FindFirst("Name").Value;
            SalesChannelId = identity.FindFirst("SalesChannelId").Value;

        }


    }
}
