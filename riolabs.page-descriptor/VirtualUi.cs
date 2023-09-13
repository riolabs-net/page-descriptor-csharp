using Riolabs.PageDescriptor.Core;
using Riolabs.PageDescriptor.Data.Page;
using Riolabs.PageDescriptor.Services;
using Riolabs.PageDescriptor.Services.YamlReader.Deserializers;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor;
public class VirtualUi : IVirtualUi
{
    private readonly VirtualUiContainer _container;
    private readonly ComponentService _componentService;
    public VirtualUi(VirtualUiContainer container, ComponentService componentService)
    {
        _container = container;
        _componentService = componentService;
    }

    public async Task LoadPageAsync(string fname)
    {
        string yamlContents = await File.ReadAllTextAsync(fname);
        IDeserializer deserializer = null;
        deserializer = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .WithNodeDeserializer(new TextDataDeserializer())
            .WithNodeDeserializer(new CustomDataDeserializer(()=> deserializer, _componentService))
            .Build();
        var page = deserializer.Deserialize<PageData>(yamlContents);
        _container.AddPage(page);
    }

    public PageData ParsePage(string fname)
    {
        throw new NotImplementedException();
    }
}
