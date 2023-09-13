using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;

public abstract class ComponentDescriptor : ComponentDescriptorBase
{
    [YamlMember(Alias = "$if")]
    public string If { get; set; }

    [YamlMember(Alias = "$for")]
    public string For { get; set; }
}

public abstract class ComponentDescriptor<T> : ComponentDescriptor, IComponentData<T> where T : class
{
    [YamlMember(Alias = "data")]
    public T Data { get; set; }

}
