using EM.UsingSwagger.Enums;
using EM.UsingSwagger.Filters;
using EM.UsingSwagger.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EM.UsingSwagger.Extensions
{
    public static class AddSwaggerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="swaggerInfo"></param>
        public static void AddSwaggerBasicAuthSecurityDefinitions(this IServiceCollection services, string xmlPath, OpenApiInfo swaggerInfo = null, string versionName = "basicauth")
        {
            SwaggerGenDefinition.SwaggerBasicAuthStartupService(services, xmlPath, swaggerInfo, versionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="swaggerInfo"></param>
        public static void AddSwaggerJWTTokenSecurityDefinitions(this IServiceCollection services, string xmlPath, OpenApiInfo swaggerInfo = null, string versionName = "jwt")
        {
            SwaggerGenDefinition.SwaggerJWTTokenStartupService(services, xmlPath, swaggerInfo, versionName);
        }
    }
}
