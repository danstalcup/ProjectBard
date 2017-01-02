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

        string Serialize<T>();

        void Deserialize(string Entity, string Json);

        void Deserialize<T>(string Json);

        ITextContent Add(string Entity, params string[] Arguments);

        ITextContent Add<T>(params string[] Arguments);

        ITextContent Remove(string Entity, params string[] Arguments);

        ITextContent Remove<T>(params string[] Arguments);        

        IList<T> GetContent<T>();

        IList<object> GetContent(string Entity);

    }
}
