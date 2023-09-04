using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Riolabs.PageDescriptor.Swashbuckle.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Riolabs.PageDescriptor.Swashbuckle.Filters;

public class FormFieldOperationFilter : ISchemaFilter
{
    private readonly SwaggerOptions _swaggerOptions;

    public FormFieldOperationFilter(SwaggerOptions swaggerOptions)
    {
        _swaggerOptions = swaggerOptions;
    }

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var propsAttributes = context.MemberInfo?.GetCustomAttributes(typeof(FormInfoAttribute), true);
        if (propsAttributes != null && propsAttributes.Length > 0)
        {
            foreach (FormInfoAttribute attribute in propsAttributes)
            {
                schema.AddExtension($"x-{_swaggerOptions.AttributePrefix}{attribute.Key}", attribute.Value);
            }
        }
    }
}