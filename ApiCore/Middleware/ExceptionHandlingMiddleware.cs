using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace ApiCore.Middleware
{
    internal static class ExceptionHandlingMiddleware
    {
        internal static void UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        await context.Response.WriteAsync(new Models.JsonErrorResponses.Response500(ex).ToString(), Encoding.UTF8);
                    }
                });
            });
        }
    }
}
