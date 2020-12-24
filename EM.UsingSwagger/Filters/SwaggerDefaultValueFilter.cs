using EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes;
using EM.UsingSwagger.Extensions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EM.UsingSwagger.Filters
{
    public class SwaggerDefaultValueFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext schemaFilterContext)
        {
            if (schema.Properties.Count == 0)
                return;

            //const BindingFlags bindingFlags = BindingFlags.Public |
            //                                  BindingFlags.NonPublic |
            //                                  BindingFlags.Instance;
            //var memberList = schemaFilterContext.Type
            //                    .GetFields(bindingFlags).Cast<MemberInfo>()
            //                    .Concat(schemaFilterContext.Type
            //                    .GetProperties(bindingFlags));

            //var excludedList = memberList.Where(m =>
            //                                    m.GetCustomAttribute<SwaggerDefaultValueAttribute>()
            //                                    != null)
            //                             .Select(m =>
            //                                 (m.GetCustomAttribute<JsonPropertyAttribute>()
            //                                  ?.PropertyName
            //                                  ?? m.Name.ToCamelCase()));

            foreach (PropertyInfo propertyInfo in schemaFilterContext.Type.GetProperties())
            {
                SwaggerDefaultValueAttribute defaultAttribute = propertyInfo
                    .GetCustomAttribute<SwaggerDefaultValueAttribute>();

                if (defaultAttribute != null)
                {
                    foreach (KeyValuePair<string, OpenApiSchema> property in schema.Properties)
                    {

                        // Only assign default value to the proper element.
                        if (propertyInfo.Name.ToCamelCase() == property.Key)
                        {
                            property.Value.Example = OpenApiAnyFactory.CreateFor(property.Value, defaultAttribute.Value);
                            break;
                        }
                    }
                }
            }
        }
    }
}
