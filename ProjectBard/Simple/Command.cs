using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class Command : ICommand
    {
        public IList<string> Arguments
        {
            get; set;
        }

        public string CommandString
        {
            get; set;
        }        
    }
}
