using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IInputDriver : IObservable<ICommand>, IDisposable
    {
        void Open();
    }
}
