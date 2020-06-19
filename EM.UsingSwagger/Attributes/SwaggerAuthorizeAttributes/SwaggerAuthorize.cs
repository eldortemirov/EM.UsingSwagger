using EM.UsingSwagger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerAuthorize:Attribute
    {
        public MethodSecurityDefinition MethodSecurity { get; }
        public SwaggerAuthorize(MethodSecurityDefinition methodSecurity = MethodSecurityDefinition.Bearer)
        {
            MethodSecurity = methodSecurity;
        }
    }
}
