using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.SwaggerParser;
public class ParameterDefinition
{
    public string Name { get; set; }
    public string Type { get; set; }
    public bool Required { get; set; }
    public ParameterLocation? In { get; set; }
    public string Example { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Type})";
    }
}
