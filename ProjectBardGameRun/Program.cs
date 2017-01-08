using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;
using ProjectBardGame.GameEngine;
using ProjectBardGame.GameContent;

namespace ProjectBardGameRun
{
    class Program
    {
        static void Main(string[] args)
        {
            IState startState = new StartGameState() ;
            Engine engine = new Engine(startState, new ContentTool(startState, new GameRepository(), new List<string> { "maze" }, new Transformer()));
        }
    }
}
