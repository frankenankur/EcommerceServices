using ApiCore.Models.Security;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ApiCore.Middleware
{
    internal static class AuthorizationMiddleware
    {
        internal static void ConfigureAuthorizations(IServiceCollection services, IList<AuthorizationPolicy> policies)
        {
            services.AddAuthorization(options =>
            {
                foreach (var authorizationPolicy in policies)
                {
                    var claimValues = new string[authorizationPolicy.ClaimValues.Count];
                    authorizationPolicy.ClaimValues.CopyTo(claimValues, 0);

                    options.AddPolicy(authorizationPolicy.PolicyName, policy =>
                        policy.RequireClaim(authorizationPolicy.ClaimName, claimValues
                    ));
                }
            });
        }
    }
}
