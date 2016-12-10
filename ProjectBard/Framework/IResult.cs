using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IResult
    {
        bool StateChanged { get; set; }

        IState ResultingState { get; set; }

        ITextContent ResultDetails { get; set; }

        ITextContent NextPrompt { get; set; }

        ICommand InitializingCommand { get; set; }
    }
}
