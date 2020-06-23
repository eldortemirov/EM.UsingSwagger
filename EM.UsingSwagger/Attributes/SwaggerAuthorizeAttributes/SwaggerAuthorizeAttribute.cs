﻿using EM.UsingSwagger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerAuthorizeAttribute:Attribute
    {
        public MethodSecurityDefinition MethodSecurity { get; }
        public SwaggerAuthorizeAttribute(MethodSecurityDefinition methodSecurity = MethodSecurityDefinition.Bearer)
        {
            MethodSecurity = methodSecurity;
        }
    }
}