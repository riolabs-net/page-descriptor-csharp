using Microsoft.Extensions.DependencyInjection;
using Riolabs.PageDescriptor;
using Riolabs.PageDescriptor.Bootstrap;
using Riolabs.PageDescriptor.Core;

var serviceCollection = new ServiceCollection();
serviceCollection.AddUIDescriptor();
var serviceProvider = serviceCollection.BuildServiceProvider();
IVirtualUi virtualUi = serviceProvider.GetRequiredService<IVirtualUi>();

virtualUi.LoadPageAsync("page.yaml").Wait();

var eee = new AlertComponent();

var o = "";