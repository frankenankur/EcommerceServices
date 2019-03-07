using ApiCore.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace ApiCore.Services.StartUpService
{
    public static class StartupManager
    {       
        public static void Configure(this IApplicationBuilder app, IList<double> versions)
        {
            app.UseExceptionHandlingMiddleware();
            app.UseSwagger();
            app.UseApiDocumentationMiddleware(versions);
            app.UseAuthentication();
            app.UseBearerTokenMiddleware();
            app.UseMvc();

        }

        public static void Configure(this IServiceCollection services, IList<double> versions, IConfiguration configuration)
        {
            LoggingMiddleware.ConfigureLoggerService(services);
            ApiDocumentationMiddleware.GenerateDocumentation(services, configuration["API:Name"], versions);
            BearerTokenMiddleware.ConfigureBearerTokenAuthentication(services, configuration);
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
