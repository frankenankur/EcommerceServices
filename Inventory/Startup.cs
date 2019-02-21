using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.IO;
using ApiCore.Services.LoggerService;
using ApiCore.Services.DocumentationService;
using ApiCore.Services.StartUpService;

namespace Inventory
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup 
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.Load();
        }


        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddOptions();
                
            services.Configure();

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Configure();
        }


    }
}
