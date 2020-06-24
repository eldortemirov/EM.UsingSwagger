using EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EM.UsingSwagger.Filters
{
    public class JWTUnauthorizeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            var isUnauthorized = (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<SwaggerUnauthorizeAttribute>().Any() ||
                                  context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerUnauthorizeAttribute>().Any()) &&
                                 !context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerBasicAuthorizeAttribute>().Any();

            if (isUnauthorized) return;

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            var jwtbearerScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ jwtbearerScheme ] = new string [] { }
                    }
                };
        }
    }
}
