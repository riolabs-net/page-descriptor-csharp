using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

[AttributeUsage(AttributeTargets.Property)]
public class ClassesAttribute : FormInfoAttribute
{
    public string Classes { get; }

    public ClassesAttribute(params string[] description)
    {
        Classes = string.Join(" ", description);
    }

    public override string Key => "class";
    public override IOpenApiExtension Value => new OpenApiString(Classes);
}
