using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerUnauthorizeAttribute : Attribute
    {
        public SwaggerUnauthorizeAttribute()
        {

        }
    }
}
