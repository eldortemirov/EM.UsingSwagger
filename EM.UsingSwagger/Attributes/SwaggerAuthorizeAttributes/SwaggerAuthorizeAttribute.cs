using EM.UsingSwagger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerAuthorizeAttribute : Attribute
    {
        public MethodTypeSecurity MethodSecurity { get; }
        public SwaggerAuthorizeAttribute(MethodTypeSecurity methodSecurity)
        {
            MethodSecurity = methodSecurity;
        }
    }
}
