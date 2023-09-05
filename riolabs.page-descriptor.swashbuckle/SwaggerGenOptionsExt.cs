using Microsoft.Extensions.DependencyInjection;
using Riolabs.PageDescriptor.Swashbuckle.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle;

public static class SwaggerGenOptionsExt
{
    public static void AddFrontendDescriptor(this SwaggerGenOptions options, SwaggerOptions swaggerOptions = default)
    {
        options.SchemaFilter<FormDataOperationFilter>(swaggerOptions ?? new());
        options.SchemaFilter<FormFieldOperationFilter>(swaggerOptions ?? new());
    }
}
