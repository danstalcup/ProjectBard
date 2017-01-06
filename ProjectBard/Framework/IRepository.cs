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

        ITextContent Add(string Entity, object Item);

        ITextContent Add<T>(T Item);

        ITextContent Remove(string Entity, object Item);

        ITextContent Remove<T>(T Item);        

        IList<T> GetContent<T>();

        IList<object> GetContent(string Entity);

    }
}
