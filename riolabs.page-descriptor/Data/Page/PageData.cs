using Riolabs.PageDescriptor.Data.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Page;
public class PageData : ComponentDescriptorBase
{
    [YamlMember(Alias = "routes")]
    public IEnumerable<string> Routes { get; set; }

    [YamlMember(Alias = "title")]
    public TextData Title { get; set; }

    [YamlMember(Alias = "subTitle")]
    public TextData SubTitle { get; set; }

    [YamlMember(Alias = "description")]
    public TextData Description { get; set; }

    [YamlMember(Alias = "meta")]
    public IEnumerable<MetaData> Meta { get; set; }
}
