using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ApiCore.Models.Enumerations
{
    public enum Claims
    {
        [Description("name")]
        Name,
        [Description("saleschannelid")]
        SalesChannelId
    }
}
