using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;
public class NavigateDescriptor
{
    [YamlMember(Alias = "path")]
    public string Path { get; set; }

    [YamlMember(Alias = "qParams")]
    public Dictionary<string, string> QueryParameters { get; set; }

    [YamlMember(Alias = "uParams")]
    public IEnumerable<string> UrlParameters { get; set; }
}
