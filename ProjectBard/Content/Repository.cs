using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;

using Newtonsoft.Json;

namespace ProjectBard.Content
{
    public class Repository : IRepository
    {
        public List<string> Strings { get; set; }

        public virtual void Initialize()
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
                    result = Serialize<string>();
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
                    Deserialize<string>(Json);
                    break;
                }
            }
        }

        public ITextContent Add(string Entity,  params string[] Arguments)
        {
            ITextContent result = new TextContent();
            switch(Entity)
            {
                case "string":
                    {
                        result = Add<string>(Arguments);
                        break;
                    }
            }
            return result;
        }

        public ITextContent Remove(string Entity, params string[] Arguments)
        {
            ITextContent result = new TextContent();
            switch (Entity)
            {
                case "string":
                    {
                        result = Remove<string>(Arguments);
                        break;
                    }
            }
            return result;
        }

        public IList<string> GetContent(string Type)
        {
            IList<string> result = Strings.ToList();                       
            return result;
        }

        public IList<T> GetContent<T>()
        {
            IList<T> result = new List<T>();
            Type type = typeof(T);
            if (type == typeof(string))            
            {
                result = Strings as List<T>;
            }
            return result;
        }

        public string Serialize<T>()
        {
            string result = string.Empty;
            Type type = typeof(T);
            if (type == typeof(string))
            {
                result = JsonConvert.SerializeObject(Strings);
            }
            return result;
        }

        public void Deserialize<T>(string Json)
        {
            Type type = typeof(T);
            if (type == typeof(string))
            {
                Strings = JsonConvert.DeserializeObject<List<string>>(Json);
            }
        }

        public ITextContent Add<T>(params string[] Arguments)
        {
            string result = string.Empty;
            Type type = typeof(T);
            if (type == typeof(string))
            {
                if (Arguments.Length > 0)
                {
                    string stringToAdd = string.Join(" ", Arguments);
                    Strings.Add(stringToAdd);
                    result = stringToAdd;
                }
                else
                {
                    throw new ArgumentException("No string passed as argument.");
                }
            }
            return new TextContent(result);
        }

        public ITextContent Remove<T>(params string[] Arguments)
        {
            string result = string.Empty;
            Type type = typeof(T);
            if (type == typeof(string))
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
            }
            return new TextContent(result);
        }

        IList<object> IRepository.GetContent(string Entity)
        {
            List<object> result = new List<object>();
            switch(Entity.ToLower())
            {
                case "string":
                    result = GetContent<string>() as List<object>;
                    break;
            }
            return result;
        }

        //public void Add(string Entity
    }
}
