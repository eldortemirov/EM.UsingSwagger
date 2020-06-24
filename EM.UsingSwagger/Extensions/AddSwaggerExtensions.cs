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
        /// Подключить Basic Auth (versionName = "basicauth")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="swaggerInfo"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerBasicAuthSecurityDefinitions(this IServiceCollection services, string xmlPath, OpenApiInfo swaggerInfo = null, string versionName = "basicauth")
        {
            SwaggerGenDefinition.SwaggerBasicAuthStartupService(services, xmlPath, swaggerInfo, versionName);
        }

        /// <summary>
        /// Подключить Basic Auth (versionName = "basicauth")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerBasicAuthSecurityDefinitions(this IServiceCollection services, string xmlPath, string versionName = "basicauth")
        {
            SwaggerGenDefinition.SwaggerBasicAuthStartupService(services, xmlPath, null, versionName);
        }

        /// <summary>
        /// Подключить Basic Auth (versionName = "basicauth")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        public static void AddSwaggerBasicAuthSecurityDefinitions(this IServiceCollection services, string xmlPath)
        {
            SwaggerGenDefinition.SwaggerBasicAuthStartupService(services, xmlPath, null, "basicauth");
        }

        /// <summary>
        /// Подключить JWT Token (versionName = "jwt")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="swaggerInfo"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerJWTTokenSecurityDefinitions(this IServiceCollection services, string xmlPath, OpenApiInfo swaggerInfo = null, string versionName = "jwt")
        {
            SwaggerGenDefinition.SwaggerJWTTokenStartupService(services, xmlPath, swaggerInfo, versionName);
        }

        /// <summary>
        /// Подключить JWT Token (versionName = "jwt")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerJWTTokenSecurityDefinitions(this IServiceCollection services, string xmlPath, string versionName = "jwt")
        {
            SwaggerGenDefinition.SwaggerJWTTokenStartupService(services, xmlPath, null, versionName);
        }

        /// <summary>
        /// Подключить JWT Token (versionName = "jwt")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        public static void AddSwaggerJWTTokenSecurityDefinitions(this IServiceCollection services, string xmlPath)
        {
            SwaggerGenDefinition.SwaggerJWTTokenStartupService(services, xmlPath, null, "jwt");
        }

        /// <summary>
        /// Подключить JWT Token и Basic Auth (versionName = "jwtbasic")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="swaggerInfo"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerJwtWithBasicSecurityDefinitions(this IServiceCollection services, string xmlPath, OpenApiInfo swaggerInfo = null, string versionName = "jwtbasic")
        {
            SwaggerGenDefinition.SwaggerJwtWithBasicAuthStartupService(services, xmlPath, swaggerInfo, versionName);
        }

        /// <summary>
        /// Подключить JWT Token и Basic Auth (versionName = "jwtbasic")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        /// <param name="versionName"></param>
        public static void AddSwaggerJwtWithBasicSecurityDefinitions(this IServiceCollection services, string xmlPath, string versionName = "jwtbasic")
        {
            SwaggerGenDefinition.SwaggerJwtWithBasicAuthStartupService(services, xmlPath, null, versionName);
        }

        /// <summary>
        /// Подключить JWT Token и Basic Auth (versionName = "jwtbasic")
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlPath"></param>
        public static void AddSwaggerJwtWithBasicSecurityDefinitions(this IServiceCollection services, string xmlPath)
        {
            SwaggerGenDefinition.SwaggerJwtWithBasicAuthStartupService(services, xmlPath, null, "jwtbasic");
        }
    }
}
