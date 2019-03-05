using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;

namespace ApiCore.Services.DocumentationService
{
    public class DocumentationManager
    {
        public static void GenerateDocumentation(IServiceCollection services, string title, IList<double> versions)
        {
            services.AddSwaggerGen(c =>
            {
                foreach (var version in versions)
                {
                    var versionString = string.Format("v{0}", version);
                    c.SwaggerDoc(versionString, new Info { Title = title, Version = versionString });
                }
                
            });
        }

        public static void GenerateUI(IApplicationBuilder app, IList<double> versions)
        {
            

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root

                foreach (var version in versions)
                {
                    var versionString = string.Format("v{0}", version);
                    c.SwaggerEndpoint(string.Format("/swagger/{0}/swagger.json", versionString), string.Format("{0} Docs", versionString));
                }
                                
                c.DisplayOperationId();
            });
        }
    }
}
