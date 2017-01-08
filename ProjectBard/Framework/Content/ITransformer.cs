using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface ITransformer
    {
        ITransformerModule<T> Module<T>();
        object Transform(string Entity, params string[] Parameters);
    }
}
