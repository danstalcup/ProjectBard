using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;

using Newtonsoft.Json;

namespace ProjectBard.ContentTool
{
    public class SimpleRepository : IRepository
    {
        public List<string> Strings { get; set; }

        public void Initialize()
        {
            Strings = new List<string>();
        }

        public string Serialize(string Entity)
        {
            string result = string.Empty;
            switch(Entity)
            {
                case "string":
                {
                    result = JsonConvert.SerializeObject(Strings);
                    break;
                }
            }
            return result;
        }

        public void Deserialize(string Entity, string Json)
        {
            switch (Entity)
            {
                case "string":
                {
                    Strings = JsonConvert.DeserializeObject<List<string>>(Json);
                    break;
                }
            }
        }

        public ITextContent Add(string Entity,  params string[] Arguments)
        {
            TextContent result = string.Empty;
            switch(Entity)
            {
                case "string":
                    {
                        if(Arguments.Length > 0)
                        {
                            string stringToAdd = string.Join(" ", Arguments);
                            Strings.Add(stringToAdd);
                            result = stringToAdd;
                        }
                        else
                        {
                            throw new ArgumentException("No string passed as argument.");
                        }
                        break;
                    }
            }
            return result;
        }

        public ITextContent Remove(string Entity, params string[] Arguments)
        {
            TextContent result = null;
            switch (Entity)
            {
                case "string":
                    {
                        if (Arguments.Length > 0)
                        {
                            Strings.Remove(Arguments[0]);
                            result = Arguments[0];
                        }
                        else
                        {
                            throw new ArgumentException("No string passed as argument.");
                        }
                        break;
                    }
            }
            return result;
        }

        public IList<object> GetContent(string Entity)
        {
            IList<object> result = new List<object>();
            switch(Entity)
            {
                case "string":
                    {
                        result = Strings.Select(s => s as object).ToList();
                        break;
                    }
            }
            return result;
        }

        //public void Add(string Entity
    }
}
