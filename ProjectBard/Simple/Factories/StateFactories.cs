using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Content;
using ProjectBard.Framework;


namespace ProjectBard.Simple
{
    public class StateFactories
    {
        public static State EmptyState()
        {
            return new State
            {
                StateDescription = new TextContent("Game Started.")                
            };
        }

        public static ContentTool ContentToolState(IState CurrentState)
        {
            return new Content.ContentTool(CurrentState, new Repository());
        }
    }
}
