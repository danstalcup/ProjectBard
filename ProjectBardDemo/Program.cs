using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Simple;
using ProjectBard.Framework;

namespace ProjectBard
{
    class Program
    {
        static void Main(string[] args)
        {
            IState startState = StateFactories.EmptyState();
            Engine engine = new Engine(startState, new Simple.ContentTool(startState, new Repository(), new List<string>(), new Transformer()));
        }
    }
}
