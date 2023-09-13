using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Riolabs.PageDescriptor.Data.Common;
public interface IComponentData<T> where T : class
{
    T Data { get; set; }
}
