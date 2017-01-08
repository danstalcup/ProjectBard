using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class Transformer : ITransformer
    {
        public ITransformerModule<T> Module<T>()
        {
            ITransformerModule<T> result = null;
            
            Type type = typeof(T);

            if(type == typeof(string))
            {
                result = new StringTransformer() as ITransformerModule<T>;
            }

            return result;
        }

        public object Transform(string Entity, params string[] Parameters)
        {
            object result = null;
            if(Entity == "string")
            {
                result = Module<string>().Construct(Parameters);
            }
            return result;
        }
    }
}
