using ApiCore.Extensions;
using ApiCore.Models.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Areas.Loyalty.Controllers
{
    [Area("Loyalty")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {

        // GET: Loyalty/Membership/5
        [HttpGet("{membershipId}", Name = "ValidateMembership")]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult<string> ValidateMembership(int membershipId)
        {
            var throwException = true;

            if (throwException)
            {
                string[] arrRetValues = null;
                if (arrRetValues.Length > 0)
                { }
                return "Not OK";
            }
            else
                return "OK";
        }

        [HttpPost, Authorize(Policy="OrderOperator")]
        public ActionResult<string> PurchaseMembership()
        {
            return HttpContext.GetClaim(Claims.SalesChannelId);
        }
    }
}
