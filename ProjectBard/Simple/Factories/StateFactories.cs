using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Simple;
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
            return new Simple.ContentTool(CurrentState, new Repository(), new List<string> { "string" }, new Transformer());
        }
    }
}
