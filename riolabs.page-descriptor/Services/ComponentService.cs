using Riolabs.PageDescriptor.Data;
using Riolabs.PageDescriptor.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Services;
public class ComponentService
{
    private readonly Dictionary<string, Type> _components;
    public ComponentService()
    {
        _components = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(ComponentDescriptor).IsAssignableFrom(x) && !x.IsAbstract)
            .SelectMany(o => o.GetCustomAttributes<ComponentAttribute>(), (t, a)=> new { a.Name, Type = t })
            .ToDictionary(x => x.Name, x => x.Type);
    }

    public Type GetComponent(string componentNameId)
    {
        if (_components.ContainsKey(componentNameId))
        {
            return _components[componentNameId];
        }
        throw new Exception($"Component {componentNameId} not found");
    }

    public ComponentTypeInfo GetInfo(Type type)
    {
        return new ComponentTypeInfo {
            HasFormInfo = typeof(FormDescriptor).IsAssignableFrom(type),
            IsForm = type.GetCustomAttributes<FromAttribute>().Any(),
            IsComponent = typeof(ComponentDescriptor).IsAssignableFrom(type),
        };
    }
}
