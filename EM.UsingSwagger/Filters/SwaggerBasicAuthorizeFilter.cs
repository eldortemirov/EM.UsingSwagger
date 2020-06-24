using EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EM.UsingSwagger.Filters
{
    public class SwaggerBasicAuthorizeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isUnauthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<SwaggerBasicAuthorizeAttribute>().Any() ||
                              context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerBasicAuthorizeAttribute>().Any();

            if (!isUnauthorized) return;

            var basicSchema = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme.",
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ basicSchema ] =   new string[] { }
                }
            };
        }
    }
}
