using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Forms;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class CustomFieldAttribute : FormInfoAttribute
{
    private string Name { get; set; }
    private string Type { get; set; }
    private string Validation { get; set; }

    public CustomFieldAttribute(string name, string type, string validation)
    {
        Name = name;
        Type = type;
        Validation = validation;
    }

    public override string Key => $"cfield-{Name}";
    public override IOpenApiExtension Value
    {
        get
        {
            var ret = new OpenApiObject() { { "type", new OpenApiString(Type) } };
            if (!string.IsNullOrEmpty(Validation))
            {
                ret.Add("validation", new OpenApiString(Validation));
            }
            return ret;
        }
    }
}