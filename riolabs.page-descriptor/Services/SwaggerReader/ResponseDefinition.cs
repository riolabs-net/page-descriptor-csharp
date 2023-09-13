using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Services.SwaggerReader;
public class ResponseDefinition
{
    public int Status { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public string SchemaId { get; set; }
    public SchemaDefinition Schema { get; set; }

    public override string ToString()
    {
        return $"{Status} {Description}";
    }
}
