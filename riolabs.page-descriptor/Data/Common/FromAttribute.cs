using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Data.Common;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public class FromAttribute : Attribute
{
}
