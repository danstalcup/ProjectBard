using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IOutputDriver : IObserver<IResult>
    {
        void Show(ITextContent Text);
    }
}
