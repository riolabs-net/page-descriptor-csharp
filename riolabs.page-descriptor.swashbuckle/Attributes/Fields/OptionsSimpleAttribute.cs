using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

public class OptionsSimpleAttribute : FormInfoAttribute
{
    public string[] Options { get; }
    public OptionsSimpleAttribute(params string[] options)
    {
        Options = options;
    }

    public override string Key => "options-simple";
    public override IOpenApiExtension Value
    {
        get
        {
            var list = new OpenApiArray();
            foreach (var option in Options)
            {
                list.Add(new OpenApiString(option));
            }
            return list;
        }
    }
}
