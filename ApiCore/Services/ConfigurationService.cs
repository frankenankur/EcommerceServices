using ApiCore.Models.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiCore.Services
{
    public class ConfigurationService
    {

        
        public IConfiguration Configuration { get; private set; }

        public ConfigurationService(IConfiguration applicationConfiguration)
        {
            Configuration = applicationConfiguration;
        }

        public string GetApiName()
        {
            var returnValue = Configuration["API:Name"];
            return returnValue;
        }

        public IList<AuthorizationPolicy> GetAPiAuthorizationPolicies()
        {
            var returnValue = new List<AuthorizationPolicy>();
            Configuration.GetSection("API:AuthorizationPolicies").Bind(returnValue);

            return returnValue.ToList();
        }
    }
}
