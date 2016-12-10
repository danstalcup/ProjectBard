using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBard.Framework
{
    public interface IRepository
    {
        void Initialize();

        string Serialize(string Entity);

        void Deserialize(string Entity, string Json);

        ITextContent Add(string Entity, params string[] Arguments);

        ITextContent Remove(string Entity, params string[] Arguments);

        IList<object> GetContent(string Entity);

    }
}
