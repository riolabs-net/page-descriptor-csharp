using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Services.SwaggerReader;
public class SchemaPropDefinition
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Format { get; set; }
    public string Example { get; set; }
    public bool Nullable { get; set; }
    public Dictionary<string, IOpenApiExtension> Meta { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Type})";
    }
}
