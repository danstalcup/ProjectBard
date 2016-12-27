using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.SimpleEngine;

namespace ProjectBardGame.GameEngine
{
    public class StartGameState : IState
    {
        public IState ReturnState
        {
            get;set;
        }

        public ITextContent StateDescription
        {
            get
            {
                return new TextContent("Welcome to Dan's Game.\n\nType \"start\" to begin.");
            }
        }

        public ITextContent ValidCommands
        {
            get
            {                             
                return TextContentFactories.EligibleCommands
                (
                    new List<string> {
                    "start - Start the latest version of the game.",
                    "start [version] - Start a specific version of the game."                    
                    }
                );                
            }
        }

        public IResult Process(ICommand Command)
        {            
            IResult result = null;
            switch (Command.Command)
            {
                case "start":
                    result = MazeFactories.MazeResult(Command, new MazeState(), true);
                    result.NextPrompt = new TextContent("Welcome to the maze generator! Create and view mazes.");
                    break;
                default:
                    result = ResultFactories.EmptyResult(Command,this);
                    break;
            }
            return result;
        }
    }
}
