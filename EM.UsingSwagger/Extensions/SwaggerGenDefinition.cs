using EM.UsingSwagger.Enums;
using EM.UsingSwagger.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Extensions
{
    public static class SwaggerGenDefinition
    {
        internal static void SwaggerJWTTokenStartupService(IServiceCollection services, string xmlPath, OpenApiInfo openApiInfo, string versionName)
        {
            services.AddSwaggerGen(options =>
            {
                if (openApiInfo == null)
                {
                    options.SwaggerDoc(versionName, new OpenApiInfo
                    {
                        Version = versionName,
                        Title = ".NET Core API",
                        Description = "A simple example ASP.NET Core Web API with JWT Token"
                    });
                }
                else
                {
                    options.SwaggerDoc(openApiInfo.Version, openApiInfo);
                }

                AddSecurityDefinition(options, MethodSecurityDefinition.Bearer);
                options.SchemaFilter<SwaggerExcludeFilter>();
                options.IncludeXmlComments(xmlPath);
                options.CustomSchemaIds(o => o.FullName);
                options.EnableAnnotations();
            });
        }

        internal static void SwaggerBasicAuthStartupService(IServiceCollection services, string xmlPath, OpenApiInfo openApiInfo, string versionName)
        {
            services.AddSwaggerGen(options =>
            {
                if (openApiInfo == null)
                {
                    options.SwaggerDoc(versionName, new OpenApiInfo
                    {
                        Version = versionName,
                        Title = ".NET Core API",
                        Description = "A simple example ASP.NET Core Web API with Basic Auth"
                    });
                }
                else
                {
                    options.SwaggerDoc(openApiInfo.Version, openApiInfo);
                }

                AddSecurityDefinition(options, MethodSecurityDefinition.BasicAuth);
                options.SchemaFilter<SwaggerExcludeFilter>();
                options.IncludeXmlComments(xmlPath);
                options.CustomSchemaIds(o => o.FullName);
                options.EnableAnnotations();
            });
        }

        internal static void SwaggerJwtWithBasicAuthStartupService(IServiceCollection services, string xmlPath, OpenApiInfo openApiInfo, string versionName)
        {
            services.AddSwaggerGen(options =>
            {
                if (openApiInfo == null)
                {
                    options.SwaggerDoc(versionName, new OpenApiInfo
                    {
                        Version = versionName,
                        Title = ".NET Core API",
                        Description = "A simple example ASP.NET Core Web API with JWT Token, Basic Auth"
                    });
                }
                else
                {
                    options.SwaggerDoc(openApiInfo.Version, openApiInfo);
                }

                AddSecurityDefinition(options, MethodSecurityDefinition.BearerWithBasic);
                options.SchemaFilter<SwaggerExcludeFilter>();
                options.IncludeXmlComments(xmlPath);
                options.CustomSchemaIds(o => o.FullName);
                options.EnableAnnotations();
            });
        }

        private static void AddSecurityDefinition(SwaggerGenOptions options, MethodSecurityDefinition methodSecurity)
        {
            switch (methodSecurity)
            {
                case MethodSecurityDefinition.BasicAuth:
                    AddSecurityDefinitionBasicAuth(options);
                    break;
                case MethodSecurityDefinition.Bearer:
                    AddSecurityDefinitionBearer(options);
                    break;
                case MethodSecurityDefinition.BearerWithBasic:
                    AddSecurityDefinitionBearerWithBasic(options);
                    break;
                default:
                    AddSecurityDefinitionBearerWithBasic(options);
                    break;
            }
        }

        private static void AddSecurityDefinitionBasicAuth(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme."
            });

            options.OperationFilter<BasicAuthorizeFilter>();
        }

        private static void AddSecurityDefinitionBearer(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
            });

            options.OperationFilter<JWTUnauthorizeFilter>();
        }

        private static void AddSecurityDefinitionBearerWithBasic(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\""
            });

            options.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme."
            });

            options.OperationFilter<JWTUnauthorizeFilter>();
            options.OperationFilter<SwaggerBasicAuthorizeFilter>();
        }
    }
}
