using ApiCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using ApiCore.Extensions;
using Newtonsoft.Json;
using System.Net;

namespace ApiCore.Middleware
{
    internal static class ExceptionHandlingMiddleware
    {
        internal static void UseApiResponseExceptionWrapping(this IApplicationBuilder app, bool developmentMode)
        {
            app.UseExceptionHandler(x =>
                {
                    x.Run(async context =>
                    {

                        var responseStatusCode = (HttpStatusCode)context.Response.StatusCode;
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        var trackingId = context.Request.GetHeader(Models.Enumerations.RequestHeaders.TrackingId);

                        context.Response.ContentType = "application/json";

                        if (ex != null)
                        {
                            var responseObj = new ApiExceptionResponse(responseStatusCode, ex.Error, trackingId, developmentMode);

                            await context.Response.WriteAsync(
                                JsonConvert.SerializeObject(responseObj)
                                ).ConfigureAwait(false);
                        }
                    });
                });
        }
    }
}
