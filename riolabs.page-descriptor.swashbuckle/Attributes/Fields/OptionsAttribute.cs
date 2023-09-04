using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

public class OptionsAttribute : FormInfoAttribute
{
    private ITextValue[] Options { get; }
    private string KeyName { get; set; } = "id";
    private string ValueName { get; set; } = "text";

    public OptionsAttribute(string key, string value, params ITextValue[] options)
    {
        Options = options;
        KeyName = key;
        ValueName = value;
    }

    public OptionsAttribute(params ITextValue[] options)
    {
        Options = options;
    }

    public override string Key => "options-simple";
    public override IOpenApiExtension Value
    {
        get
        {
            var list = new OpenApiArray();
            var  _options = Options?.Select(x => new OpenApiObject
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
