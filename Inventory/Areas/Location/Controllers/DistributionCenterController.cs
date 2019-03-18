using ApiCore.Middleware;
using ApiCore.Models;
using ApiCore.Extensions;
using ApiCore.Models.Enumerations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace Inventory.Areas.Location.Controllers
{
    /// <summary></summary>
    [Area("Location")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class DistributionCenterController : ControllerBase
    {

        private readonly LoggingMiddleware _logger;

        public DistributionCenterController(LoggingMiddleware logger)
        {
            _logger = logger;
        }

        [HttpGet("v1/{itemNumber}", Name = "GetDistributionCenterByItem")]
        public string GetDistributionCenterByItem(
            [FromRoute, SwaggerParameter("Costco Item Number", Required = true)] int itemNumber)
        {
            //throw new ApiExceptionResponse(HttpStatusCodes.InternalServerError_500, new Exception(), Request.GetHeader(RequestHeaders.TrackingId), true);
            throw new Exception();

            //try
            //{
            //    _logger.LogInfo("Yeah");
            //    _logger.LogError("Yeah");
            //    return string.Format("{0} {1}", "you are looking for a place that sells itemNumber", itemNumber);
                
            //}
            //catch (Exception ex)
            //{
                
            //    _logger.LogError(ex.Message);
               
            //}

            
        }


        [HttpGet("v1", Name = "GetAllDistributionCenters")]
        public string GetDistributionCenters()
        {
            try
            {
                return "OK";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("v1", Name = "GetAllDistributionCentersBruce")]
        public string HelloBruce()
        {
            return "he";
        }


        [HttpPost("v1", Name = "Keith")]
        public string HelloKeith()
        {
            return "Keith";
        }



    }
}
