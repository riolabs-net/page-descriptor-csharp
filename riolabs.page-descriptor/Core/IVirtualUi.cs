using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Core;
public interface IVirtualUi
{
    Task LoadPageAsync(string fname);
}
