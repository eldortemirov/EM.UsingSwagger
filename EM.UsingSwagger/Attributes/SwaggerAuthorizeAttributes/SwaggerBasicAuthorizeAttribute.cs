using System;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    /// <summary>
    /// Basic Authorize в запросе по полям userName password
    /// </summary>
    [AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public class SwaggerBasicAuthorizeAttribute : Attribute
    {
        public SwaggerBasicAuthorizeAttribute()
        {

        }
    }
}
