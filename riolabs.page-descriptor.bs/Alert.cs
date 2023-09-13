using Riolabs.PageDescriptor.Data.Common;
using Riolabs.PageDescriptor.Data.Components;

namespace Riolabs.PageDescriptor.Bootstrap;

public class AlertData
{
    public string Color { get; set; }
    public string Text { get; set; }
}

[Component("rlb-alert-component")]
public class AlertComponent : ComponentDescriptor<AlertData> { }