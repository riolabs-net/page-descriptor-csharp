using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;
public class FieldDefinitionsAttribute : FormInfoAttribute
{
    private string Method { get; set; }
    private string Path { get; set; }
    public FieldDefinitionsAttribute(string options)
    {
        string pattern = @"<([^>]+)>\s+(.+)";
        List<ITextValue> optionsList = new();
        Match match = Regex.Match(options, pattern);
        if (match.Success)
        {
            Method = match.Groups[1].Value;
            Path = match.Groups[2].Value;
        };
    }

    public override string Key => "options-simple";
    public override IOpenApiExtension Value
    {
        get
        {
            return new OpenApiObject
            {
                { "method", new OpenApiString(Method) },
                { "path", new OpenApiString(Path) }
            };
        }
    }
}
