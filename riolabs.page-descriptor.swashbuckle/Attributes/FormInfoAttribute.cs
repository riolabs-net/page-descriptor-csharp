using Microsoft.OpenApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle.Attributes;

public abstract class FormInfoAttribute : Attribute
{
    public abstract string Key { get; }
    public abstract IOpenApiExtension Value { get; }
}
