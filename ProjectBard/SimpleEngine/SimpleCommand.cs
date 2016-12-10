using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class SimpleCommand : ICommand
    {
        public IList<string> Arguments
        {
            get; set;
        }

        public string Command
        {
            get; set;
        }        
    }
}
