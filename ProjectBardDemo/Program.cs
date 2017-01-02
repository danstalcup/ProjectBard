using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Simple;
using ProjectBard.Framework;
using ProjectBard.Content;

namespace ProjectBard
{
    class Program
    {
        static void Main(string[] args)
        {
            IState startState = StateFactories.EmptyState();
            Engine engine = new Engine(startState, new Content.ContentTool(startState, new Repository()));
        }
    }
}
