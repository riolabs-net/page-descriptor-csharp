using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Page;
public class MetaData
{
    [YamlMember(Alias = "name")]
    public string Name { get; set; }

    [YamlMember(Alias = "content")]
    public string Content { get; set; }

    [YamlMember(Alias = "http-equiv")]
    public string HttpEquiv { get; set; }
}
