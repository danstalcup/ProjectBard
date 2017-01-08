using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IEngine : IObservable<IResult>, IObserver<ICommand>, IDisposable
    {
        IState CurrentState { get; }

        IResult LatestResult { get; }

        IResult Process(ICommand Command);        

        bool IsEngineActive { get; }

        bool HasContentToolPermission { get; set; }

        IInputDriver Input { get; set; }

        IOutputDriver Output { get; set; }

        IContentTool ContentTool { get; set; }
    }
}
