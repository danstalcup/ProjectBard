using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class CommandFactories
    {
        public static SimpleCommand StartCommand()
        {
            return new SimpleCommand
            {
                Command = "start",
                Arguments = new string[0]
            };
        }
    }
}
