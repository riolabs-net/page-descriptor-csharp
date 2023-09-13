using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;
public class ApiDescriptor
{
    [YamlMember(Alias = "action")]
    public string Action { get; set; }

    [YamlMember(Alias = "method")]
    public string Method { get; set; }
}
