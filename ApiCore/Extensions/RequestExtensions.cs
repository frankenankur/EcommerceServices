using ApiCore.Models.Enumerations;
using Microsoft.AspNetCore.Http;

namespace ApiCore.Extensions
{
    public static class RequestExtensions
    {
        public static string GetHeader(this HttpRequest request, RequestHeaders headerKey)
        {
            return request.Headers[headerKey.GetDescription()];

        }
    }
}
