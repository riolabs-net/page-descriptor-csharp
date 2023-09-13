using Riolabs.PageDescriptor.Data.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor;
public class VirtualUiContainer
{
    private readonly Dictionary<string, PageData> pages = new();

    public void AddPage(PageData page)
    {
        pages.Add(page.Id, page);
    }
}
