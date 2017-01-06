using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IFactory<T>
    {
        T Construct(params string[] Parameters);
    }
}
