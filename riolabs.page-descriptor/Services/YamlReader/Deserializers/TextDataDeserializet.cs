using Riolabs.PageDescriptor.Data.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Services.YamlReader.Deserializers;
public class TextDataDeserializer : INodeDeserializer
{
    public bool Deserialize(IParser parser, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
    {
        if (expectedType == typeof(TextData))
        {
            if (parser.TryConsume<Scalar>(out var scalar))
            {
                value = new TextData { Text = scalar.Value };
                return true;
            }
        }

        value = null;
        return false;
    }
}
