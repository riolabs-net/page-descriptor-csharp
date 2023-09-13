using Microsoft.Extensions.DependencyInjection;
using Riolabs.PageDescriptor.Core;
using Riolabs.PageDescriptor.Services;
using Riolabs.PageDescriptor.Services.SwaggerReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor;
public static class PageDescriptorExt
{
    public static void AddUIDescriptor(this IServiceCollection services)
    {
        services.AddSingleton(BuildInstance());
    }

    private static IVirtualUi BuildInstance()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<VirtualUiContainer>();
        serviceCollection.AddSingleton<ISwaggerReader, SwaggerReaderService>();
        serviceCollection.AddSingleton<IVirtualUi, VirtualUi>();
        serviceCollection.AddSingleton<ComponentService>();
        IServiceProvider provider = serviceCollection.BuildServiceProvider();
        return provider.GetService<IVirtualUi>();
    }
}
