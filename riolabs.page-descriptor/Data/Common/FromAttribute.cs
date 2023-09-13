using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Data.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class FromAttribute : Attribute
{
    public string Name { get; set; }
    public FromAttribute(string name)
    {
        Name = name;
    }
}
