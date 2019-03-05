using ApiCore.Services.DocumentationService;
using ApiCore.Services.LoggerService;
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
            app.UseMvc();
            app.UseSwagger();
            DocumentationManager.GenerateUI(app, versions);
        }

        public static void Configure(this IServiceCollection services, IList<double> versions, string apiName)
        {

            DocumentationManager.GenerateDocumentation(services, apiName, versions);
            LoggerManager.ConfigureLoggerService(services);
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
