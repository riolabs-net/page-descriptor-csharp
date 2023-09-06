using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor;

public abstract class Component
{
    public List<Component> Components { get; set; }
}
