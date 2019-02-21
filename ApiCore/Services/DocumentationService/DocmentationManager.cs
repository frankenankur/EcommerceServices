using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiCore.Services.DocumentationService
{
    public class DocumentationManager
    {
        public static void GenerateDocumentation(IServiceCollection services, string title, double version)
        {
            var versionString = string.Format("v{0}", version);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(versionString, new Info { Title = title, Version = versionString });
            });
        }

        public static void GenerateUI(IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = ""; // serve the UI at root
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 Docs");
                c.DisplayOperationId();
            });
        }
    }
}
