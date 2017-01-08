using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class Result : IResult
    {
        public ICommand InitializingCommand
        {
            get; set;
        }

        public ITextContent NextPrompt
        {
            get; set;
        }

        public ITextContent ResultDetails
        {
            get; set;
        }

        public IState ResultingState
        {
            get; set;
        }

        public bool StateChanged
        {
            get; set;
        }
    }
}
