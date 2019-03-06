using ApiCore.Services.DocumentationService;
using ApiCore.Services.LoggerService;
using ApiCore.Services.ExceptionService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ApiCore.Services.StartUpService
{
    public static class StartupManager
    {       
        public static void Configure(this IApplicationBuilder app, IList<double> versions)
        {
            app.LoadExceptionHandler();
            app.UseSwagger();
            DocumentationManager.GenerateUI(app, versions);
            app.UseMvc();
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
