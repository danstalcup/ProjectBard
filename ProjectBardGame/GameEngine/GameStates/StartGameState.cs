using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.SimpleEngine;

namespace ProjectBardGame.GameEngine.GameStates
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
                throw new NotImplementedException();
            }
        }

        public IResult Process(ICommand Command)
        {
            throw new NotImplementedException();
        }
    }
}
