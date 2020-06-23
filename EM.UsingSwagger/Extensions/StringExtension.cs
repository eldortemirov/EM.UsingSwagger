using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Extensions
{
    public static class StringExtension
    {
        public static string ToCamelCase(this string str) => string.IsNullOrEmpty(str) || str.Length < 2 ? str : Char.ToLowerInvariant(str[0]) + str.Substring(1);
    }
}
