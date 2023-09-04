using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

[AttributeUsage(AttributeTargets.Property)]
public class SortAttribute : FormInfoAttribute
{
    private int Position { get; }

    public SortAttribute(int position)
    {
       Position = position;
    }

    public override string Key => "position";
    public override IOpenApiExtension Value => new OpenApiInteger(Position);
}
