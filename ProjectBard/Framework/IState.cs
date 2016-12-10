using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IState
    {
        ITextContent StateDescription { get; }

        ITextContent ValidCommands { get; }

        IResult Process(ICommand Command);

        IState ReturnState { get; set; }
    }
}
