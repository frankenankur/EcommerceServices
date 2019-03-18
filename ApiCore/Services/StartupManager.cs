using ApiCore.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApiCore.Services
{
    public static class StartupManager
    {       
        public static void Configure(this IApplicationBuilder app, IHostingEnvironment env, IList<double> versions)
        {

            app.UseSwagger();
            app.UseApiDocumentationMiddleware(versions);
            app.UseAuthentication();
            app.UseBearerTokenMiddleware();
            if (env.IsDevelopment())
            {
                app.UseApiResponseExceptionWrapping(true);
            } else
            {
                app.UseApiResponseExceptionWrapping(false);
            }
            
            app.UseMvc();
            

        }

        public static void Configure(this IServiceCollection services, IList<double> versions, ConfigurationService configurationService)
        {
            LoggingMiddleware.ConfigureLoggerService(services);
            ApiDocumentationMiddleware.GenerateDocumentation(services, configurationService, versions);
            BearerTokenMiddleware.ConfigureBearerTokenAuthentication(services, configurationService);
            AuthorizationMiddleware.ConfigureAuthorizations(services, configurationService.GetAPiAuthorizationPolicies());
        }

        public static void Load(this IConfiguration configuration)
        {
            var path = String.Format(@"{0}\nlog.config", Directory.GetCurrentDirectory());
            LogManager.LoadConfiguration(path);
        }

        public static void AddOptions(this IMvcBuilder mvc)
        {
            mvc.AddJsonOptions(options =>
            {
                options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            });
        }
    }
}
