using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riolabs.PageDescriptor.Swashbuckle
{
    public interface ITextValue
    {
        string Text { get; }
        string Id { get; }
    }

    public class TextValue : ITextValue
    {
        public string Text { get; set; }
        public string Id { get; set; }
    }   
}
