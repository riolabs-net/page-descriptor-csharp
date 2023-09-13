using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Services.SwaggerReader;
public class SchemaDefinition
{
    public string Type { get; set; }
    public string SchemaId { get; set; }
    public string[] RequiredFields { get; set; }
    public List<SchemaPropDefinition> Properties { get; set; }
    public Dictionary<string, IOpenApiExtension> Meta { get; set; }

    public override string ToString()
    {
        return $"{SchemaId} ({Type})";
    }
}
