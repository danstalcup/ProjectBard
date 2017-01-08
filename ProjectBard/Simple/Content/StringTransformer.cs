using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class StringTransformer : ITransformerModule<string>
    {
        public string Construct(params string[] Parameters)
        {
            return string.Join(" ", Parameters);
        }
    }
}
