using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;
public abstract class ComponentDescriptorBase
{
    [YamlMember(Alias = "id")]
    public string Id { get; set; }

    [YamlMember(Alias = "component")]
    public string Component { get; set; }

    [YamlMember(Alias = "apis")]
    public Dictionary<string, ApiDescriptor> Apis { get; set; }

    [YamlMember(Alias = "components")]
    public IEnumerable<ComponentDescriptor> Components { get; set; }
}
