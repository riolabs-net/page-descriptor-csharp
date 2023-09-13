using Riolabs.PageDescriptor.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data;

public class CardData
{
    [YamlMember(Alias = "text")]
    public string Text { get; set; }

    [YamlMember(Alias = "title")]
    public string Title { get; set; }

    [YamlMember(Alias = "image")]
    public string Image { get; set; }

}

[Component("rlb-card-component")]
public class CardComponent : ComponentDescriptor<CardData> { }