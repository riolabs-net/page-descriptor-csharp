using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Services.SwaggerReader;
public class MethodDefinition
{
    public string Path { get; set; }
    public string Verb { get; set; }

    public List<ParameterDefinition> Params { get; set; } = new();
    public List<ResponseDefinition> Responses { get; set; } = new();

    public override string ToString()
    {
        return $"{Verb.ToUpper()} {Path}";
    }
}
