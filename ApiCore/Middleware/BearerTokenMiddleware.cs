using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Linq;
using ApiCore.Services;

namespace ApiCore.Middleware
{
    internal static class BearerTokenMiddleware
    {
        internal static IApplicationBuilder UseBearerTokenMiddleware(this IApplicationBuilder app, string schema = "Bearer")
        {
            return app.Use((async (context, next) =>
            {
                IIdentity identity = context.User.Identity;
                if ((identity != null ? (!identity.IsAuthenticated ? 1 : 0) : 1) != 0)
                {
                    AuthenticateResult authenticateResult = await context.AuthenticateAsync(schema);
                    if (authenticateResult.Succeeded && authenticateResult.Principal != null)
                        context.User = authenticateResult.Principal;                    
                }
                await next();
            }));
        }

        internal static void ConfigureBearerTokenAuthentication(IServiceCollection services, ConfigurationService configurationService)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = false,
                        ValidIssuer = configurationService.Configuration["Jwt:Issuer"],
                        ValidAudience = configurationService.Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationService.Configuration["Jwt:Key"]))
                    };
                });
        }
    }
}
