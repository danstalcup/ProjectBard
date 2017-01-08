using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface ITransformerModule<T>
    {
        T Construct(params string[] Parameters);
    }
}
