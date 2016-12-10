using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.SimpleEngine;
using ProjectBard.Framework;
using ProjectBard.ContentTool;

namespace ProjectBard
{
    class Program
    {
        static void Main(string[] args)
        {
            IState startState = StateFactories.EmptyState();
            ConEngine engine = new ConEngine(startState, new SimpleContentTool(startState, new SimpleRepository()));
        }
    }
}
