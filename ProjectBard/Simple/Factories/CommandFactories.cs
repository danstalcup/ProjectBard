using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class CommandFactories
    {
        public static Command StartCommand()
        {
            return new Command
            {
                CommandString = "start",
                Arguments = new string[0]
            };
        }
    }
}
