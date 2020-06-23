using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Attributes.SwaggerAuthorizeAttributes
{
    /// <summary>
    /// Атрибут игнорирует свойства из swagger для запроса
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerIgnoreAttribute : Attribute
    {
    }
}
