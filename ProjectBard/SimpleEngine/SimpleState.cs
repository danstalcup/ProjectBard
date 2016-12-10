using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class SimpleState : IState
    {
        public IState ReturnState
        {
            get; set;
        }

        public ITextContent StateDescription
        {
            get; set;            
        }

        public ITextContent ValidCommands
        {
            get
            {
                return TextContentFactories.EligibleCommands(new List<string>());
            }
        }

        public IResult Process(ICommand Command)
        {
            return ResultFactories.EmptyResult(Command, this);
        }
    }
}
