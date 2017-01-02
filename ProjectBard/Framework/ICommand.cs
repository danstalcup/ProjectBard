using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface ICommand
    {
        string CommandString { get; set; }

        IList<string> Arguments { get; set; }
    }
}
