using Riolabs.PageDescriptor.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Components;
public abstract class ComponentFormDescriptor : ComponentDescriptor
{
 
}

public abstract class ComponentFormDescriptor<T> : ComponentFormDescriptor, IComponentData<T> where T : class
{
    [YamlMember(Alias = "data")]
    public T Data { get; set; }

}