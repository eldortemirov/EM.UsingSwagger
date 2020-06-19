using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.UsingSwagger.Models
{
    public class AddSwaggerInfo
    {
        public string Version { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public OpenApiContact Contact { get; set; }

        public OpenApiLicense License { get; set; }
    }
}
