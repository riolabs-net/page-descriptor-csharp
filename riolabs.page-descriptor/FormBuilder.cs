using Riolabs.PageDescriptor.SwaggerParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor;

public abstract class FormBuilder
{
    public string SwaggerFile { get; set; }
    public string Path { get; set; }
    public string Verb { get; set; }

    private readonly SwaggerReader _swaggerReader;

    public FormBuilder(string swaggerFile, string path, string verb)
    {
        SwaggerFile = swaggerFile;
        Path = path;
        Verb = verb;
        _swaggerReader = new SwaggerReader(SwaggerFile);
        var method = _swaggerReader.Methods.FirstOrDefault(m => m.Path == Path && m.Verb == Verb);

    }
}
