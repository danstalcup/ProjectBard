using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBardGame.GameComponents;
using ProjectBard.Framework;
using ProjectBard.SimpleEngine;

namespace ProjectBardGame.GameEngine
{
    public class MazeFactories
    {
        public static Result MazeResult(ICommand Command, MazeState State, bool StateChanged)
        {
            Result result = ResultFactories.InformationalResult(Command, State, (State.Maze == null ? new TextContent() : State.Maze.Display), new TextContent("Type the next command."));
            result.StateChanged = StateChanged;
            return result;
        }        

    }
}
