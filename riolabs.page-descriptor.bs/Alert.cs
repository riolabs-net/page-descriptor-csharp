using Riolabs.PageDescriptor.Data.Common;

namespace Riolabs.PageDescriptor.Bootstrap;

public class AlertData
{
    public string Color { get; set; }
    public string Text { get; set; }
}

[Component("rlb-alert-component")]
public class AlertComponent : ComponentDescriptor<AlertData> { }