using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.SimpleEngine;
using ProjectBard.ContentTool;
using ProjectBardGame.GameComponents;
using ProjectBardGame.GameEngine;

namespace ProjectBardGameRun
{
    class Program
    {
        static void Main(string[] args)
        {
            IState startState = new StartGameState() ;
            ConEngine engine = new ConEngine(startState, new SimpleContentTool(startState, new SimpleRepository()));
        }
    }
}
