using ApiCore.Models.Enumerations;
using System.Security.Claims;

namespace ApiCore.Extensions
{
    public static class ClaimsExtensions
    {
        public static string GetClaim(this Microsoft.AspNetCore.Http.HttpContext context, Claims claim)
        {
            var identity = (ClaimsIdentity)context.User.Identity;
            return identity.FindFirst(claim.GetDescription()).Value;
        }
    }
}
