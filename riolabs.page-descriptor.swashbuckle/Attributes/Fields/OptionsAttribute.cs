using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

public class OptionsAttribute : FormInfoAttribute
{
    private IEnumerable<ITextValue> Options { get; }
    public string KeyName { get; set; } = "id";
    public string ValueName { get; set; } = "text";

    public OptionsAttribute(params string[] options)
    {
        string pattern = @"<([^>]+)>\s+(.+)";
        List<ITextValue> optionsList = new List<ITextValue>();
        Options = options.Select(o =>
           {
               Match match = Regex.Match(o, pattern);
               if (match.Success)
               {
                   return new TextValue
                   {
                       Id = match.Groups[1].Value,
                       Text = match.Groups[2].Value
                   };
               }
               else
               {
                   throw new Exception($"Invalid option format: {o}");
               }
           });
    }

    public override string Key => "options-simple";
    public override IOpenApiExtension Value
    {
        get
        {
            var list = new OpenApiArray();
            var _options = Options?.Select(x => new OpenApiObject
            {
                { KeyName, new OpenApiString(x.Id) },
                { ValueName, new OpenApiString(x.Text) }
            });
            foreach (var option in _options)
            {
                list.Add(option);
            }
            return list;
        }
    }
}
