using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.ContentTool;
using ProjectBard.Framework;


namespace ProjectBard.SimpleEngine
{
    public class StateFactories
    {
        public static SimpleState EmptyState()
        {
            return new SimpleState
            {
                StateDescription = new TextContent("Game Started.")                
            };
        }

        public static SimpleContentTool ContentToolState(IState CurrentState)
        {
            return new SimpleContentTool(CurrentState, new SimpleRepository());
        }
    }
}
