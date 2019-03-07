using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCore.Filters
{
    internal class HeaderFilter : IOperationFilter
    {
        void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "costco.trackingId",
                In = "header",
                Type = "string",
                Required = true
            });

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "costco.env",
                In = "header",
                Type = "string",
                Required = true
            });
        }
    }
}
