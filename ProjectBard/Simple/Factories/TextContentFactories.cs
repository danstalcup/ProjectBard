using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class TextContentFactories
    {
        public static TextContent EligibleCommands(IList<string> Commands, bool HasContentToolPermission=true)
        {

            var DefaultCommands = new List<string>
                {
                    "state - See the state of the game",
                    "commands - See a list of eligible commands",
                    "help - See info using this console",
                    "exitgame - Exit the game"        
                };
            if(HasContentToolPermission)
            {
                DefaultCommands.Add("content - Activate content tool");
            }

            foreach(var command in DefaultCommands)
            {
                Commands.Add(command);
            }

            return new TextContent(Commands);
        }
    }
}
