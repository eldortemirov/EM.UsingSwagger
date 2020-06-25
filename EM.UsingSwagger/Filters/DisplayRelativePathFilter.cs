using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Filters
{
    public class DisplayRelativePathFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Description = $"Relative Path: &nbsp;&nbsp;&nbsp;{context.ApiDescription.RelativePath}";
        }
    }
}
