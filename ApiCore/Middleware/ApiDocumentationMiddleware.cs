using ApiCore.Extensions;
using ApiCore.Filters;
using ApiCore.Models.Enumerations;
using ApiCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;

namespace ApiCore.Middleware
{
    internal static class ApiDocumentationMiddleware
    {
        internal static void UseApiDocumentationMiddleware(this IApplicationBuilder app, IList<double> versions)
        {
            app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = string.Empty;

                    foreach (var version in versions)
                    {
                        var versionString = string.Format("v{0}", version);
                        c.SwaggerEndpoint(string.Format("/swagger/{0}/swagger.json", versionString), string.Format("{0} Docs", versionString));
                    }
                    c.DocExpansion(DocExpansion.List);
                    c.DisplayOperationId();
                });
        }

        internal static void GenerateDocumentation(IServiceCollection services, ConfigurationService configurationService , IList<double> versions)
        {
            services.AddSwaggerGen(c =>
            {
                foreach (var version in versions)
                {
                    var versionString = string.Format("v{0}", version);
                    c.SwaggerDoc(versionString, new Info { Title = configurationService.GetApiName(), Version = versionString });
                }

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", System.Array.Empty<string>()},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = RequestHeaders.AutorizationToken.GetDescription(),
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(security);

                c.OperationFilter<HeaderFilter>();
            });
        }
    }
}
