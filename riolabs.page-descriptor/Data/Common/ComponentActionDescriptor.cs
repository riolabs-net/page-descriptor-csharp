using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;
public abstract class ComponentActionDescriptor : ComponentDescriptor
{
    [YamlMember(Alias = "navigate")]
    public NavigateDescriptor Navigate { get; set; }

    [YamlMember(Alias = "function")]
    public string FunctionName { get; set; }    
}

public abstract class ComponentActionDescripto<T> : ComponentActionDescriptor, IComponentData<T> where T : class
{
    [YamlMember(Alias = "data")]
    public T Data { get; set; }

}