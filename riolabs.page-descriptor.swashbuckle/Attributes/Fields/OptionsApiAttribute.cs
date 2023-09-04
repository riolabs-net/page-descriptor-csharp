using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes.Fields;

public class OptionsApiAttribute : FormInfoAttribute
{
    private string KeyName { get; set; } = "id";
    private string ValueName { get; set; } = "text";
    private string Verb { get; set; } = "GET";
    private string Url { get; set; }

    public OptionsApiAttribute(string url)
    {
        Url = url;
    }

    public OptionsApiAttribute(string url, string verb) : this(url)
    {
        Verb = verb;
    }

    public OptionsApiAttribute(string url, string verb, string key, string value) : this(url, verb)
    {
        KeyName = key;
        ValueName = value;
    }

    public override string Key => "options-api";
    public override IOpenApiExtension Value
    {
        get
        {
            var ret = new OpenApiObject() { { "url", new OpenApiString(Url) }, { "verb", new OpenApiString(Verb) } };
            if (string.IsNullOrEmpty(KeyName))
            {
                ret.Add("id", new OpenApiString(KeyName));
            }
            if (string.IsNullOrEmpty(ValueName))
            {
                ret.Add("text", new OpenApiString(ValueName));
            }
            return ret;
        }
    }
}
