using EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes;
using EM.UsingSwagger.Enums;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EM.UsingSwagger.Filters
{
    public class SwaggerAuthorizeFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isUnauthorized = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<SwaggerAuthorizeAttribute>().Any() ||
                              context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerAuthorizeAttribute>().Any();

            if (!isUnauthorized) return;

            var methodSecurity = context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerAuthorizeAttribute>().Select(s => s.MethodSecurity).Distinct().FirstOrDefault();

            switch (methodSecurity)
            {
                case MethodTypeSecurity.Bearer:
                    SetBearerSecurity(operation);
                    break;
                case MethodTypeSecurity.Basic:
                    SetBasicSecurity(operation);
                    break;
            }
        }

        private static void SetBasicSecurity(OpenApiOperation operation)
        {
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

        private static void SetBearerSecurity(OpenApiOperation operation)
        {
            var bearerSchema = new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ bearerSchema ] =   new string[] { }
                }
            };
        }
    }
}
