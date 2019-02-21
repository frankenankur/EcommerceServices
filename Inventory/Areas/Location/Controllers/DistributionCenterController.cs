using ApiCore.Services.LoggerService;
using ApiCore.Business.Entities.Errors;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;


namespace Inventory.Areas.Location.Controllers
{
    /// <summary></summary>
    [Area("Location")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class DistributionCenterController : ControllerBase
    {

        private readonly ILoggerManager _logger;

        public DistributionCenterController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet("v1/{itemNumber}", Name = "GetDistributionCenterByItem")]
        [ProducesResponseType(typeof(ApiErrorResponse), 400)]
        [ProducesResponseType(typeof(ApiErrorResponse), 500)]
        public string GetDistributionCenterByItem(
            [FromRoute, SwaggerParameter("Costco Item Number", Required = true)] int itemNumber)
        {
            try
            {
                _logger.LogInfo("Yeah");
                _logger.LogError("Yeah");
                return string.Format("{0} {1}", "you are looking for a place that sells itemNumber", itemNumber);
                
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return new ApiErrorResponse(ex.HResult, ex.TargetSite.Name, ex.Message).ToString();
            }

            
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
