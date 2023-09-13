using Riolabs.PageDescriptor.Data;
using Riolabs.PageDescriptor.Data.Components;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Services.YamlReader.Deserializers;
public class CustomDataDeserializer : INodeDeserializer
{
    private readonly Func<IDeserializer> _deserializer;
    private readonly ComponentService _componentService;
    public CustomDataDeserializer(Func<IDeserializer> deserializer, ComponentService componentService)
    {
        _deserializer = deserializer;
        _componentService = componentService;
    }

    private class _Component
    {
        [YamlMember(Alias = "component")]
        public string Component { get; set; }
    }


    public bool Deserialize(IParser parser, Type expectedType, Func<IParser, Type, object> nestedObjectDeserializer, out object value)
    {
        if (expectedType == typeof(ComponentDescriptor))
        {
            dynamic o = nestedObjectDeserializer(parser, typeof(object));
            var serializer = new SerializerBuilder().Build();
            var type = _componentService.GetComponent(o["component"].ToString());
            value = _deserializer().Deserialize(serializer.Serialize(o), type);
            return true;
        }

        value = null;
        return false;
    }
}