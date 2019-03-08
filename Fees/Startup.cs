using ApiCore.Services;
using ApiCore.Services.StartUpService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Fees
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {

        private static List<double> PublishedVersions => new List<double>() { 1.0 };
        private static ConfigurationService ConfigurationService;

        public Startup(IConfiguration configuration)
        {
            ConfigurationService = new ConfigurationService(configuration);
            Configuration = configuration;
            configuration.Load();
        }


        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddOptions();

            services.Configure(PublishedVersions, ConfigurationService);

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Configure(PublishedVersions);
        }


    }
}
