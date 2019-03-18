using System.ComponentModel;

namespace ApiCore.Models.Enumerations
{
    public enum RequestHeaders
    {
        [Description("costco.trackingId")]
        TrackingId,
        [Description("costco.env")]
        Environment,
        [Description("authorization")]
        AutorizationToken
    }
}
