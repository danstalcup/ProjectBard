using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;
using ProjectBardGame.GameContentTool;

namespace ProjectBardGame.GameEngine
{
    public class MazeSelectorState : IState
    {
        public MazeSelectorState(GameRepository Repository)
        {
            _repository = Repository;
        }

        public IState ReturnState
        {
            get; set;
        }

        public ITextContent StateDescription
        {
            get
            {
                return new TextContent(); 
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

        private readonly GameRepository _repository;
    }
}
