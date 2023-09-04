using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Riolabs.PageDescriptor.Swashbuckle.Attributes;
using Riolabs.PageDescriptor.Swashbuckle.Attributes.Forms;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle;

public class FormDataOperationFilter : ISchemaFilter
{
    private readonly SwaggerOptions _swaggerOptions;
    public FormDataOperationFilter(SwaggerOptions swaggerOptions)
    {
        _swaggerOptions = swaggerOptions;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var classAttributes = context.Type?.GetCustomAttributes(typeof(FormInfoAttribute), true);
        if (classAttributes != null && classAttributes.Length > 0)
        {
            foreach (FormInfoAttribute attribute in classAttributes)
            {
                schema.AddExtension($"x-{_swaggerOptions.AttributePrefix}{attribute.Key}", attribute.Value);
            }
            if (classAttributes.Where(o => o is CustomFieldAttribute).Any())
            {
                schema.AdditionalPropertiesAllowed = true;
            }
        }
    }
}