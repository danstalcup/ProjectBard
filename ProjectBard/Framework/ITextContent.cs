using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface ITextContent
    {
        string Content { get; set;  }

        IList<string> ContentLines { get; set; }

        ITextContent AppendLine(string Line);

        ITextContent AppendLines(List<string> Lines);

        ITextContent Append(ITextContent Text);        
    }
}
