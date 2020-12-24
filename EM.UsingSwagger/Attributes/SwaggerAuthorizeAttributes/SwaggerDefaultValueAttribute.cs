using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerDefaultValueAttribute : Attribute
    {
        public object Value { get; }
        public SwaggerDefaultValueAttribute(object value)
        {
            Value = value;
        }
    }
}
