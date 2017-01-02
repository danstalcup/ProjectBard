using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Content;
using ProjectBard.Framework;

namespace ProjectBardGame.GameContentTool
{
    public class GameRepository : IRepository
    {
        public ITextContent Add(string Entity, params string[] Arguments)
        {
            throw new NotImplementedException();
        }

        public void Deserialize(string Entity, string Json)
        {
            throw new NotImplementedException();
        }

        public IList<object> GetContent(string Entity)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public ITextContent Remove(string Entity, params string[] Arguments)
        {
            throw new NotImplementedException();
        }

        public string Serialize(string Entity)
        {
            throw new NotImplementedException();
        }
    }
}
