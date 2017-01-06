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

        public ITextContent Add(string Entity,  object Item)
        {
            ITextContent result = new TextContent();
            switch(Entity)
            {
                case "string":
                    {
                        result = Add<string>(Item as string);
                        break;
                    }
            }
            return result;
        }

        public ITextContent Remove(string Entity, object Item)
        {
            ITextContent result = new TextContent();
            switch (Entity)
            {
                case "string":
                    {
                        result = Remove<string>(Item as string);
                        break;
                    }
            }
            return result;
        }

        public IList<object> GetContent(string Entity)
        {
            IList<object> result = new List<object>();

            if (Entity == "string")
            {
                result = Strings.Select(m => m as object).ToList();
            }

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

        public ITextContent Add<T>(T item)
        {            
            bool itemAdded = false;

            Type type = typeof(T);
            if (type == typeof(string))
            {
                Strings.Add(item as string);
                itemAdded = true;               
            }

            string result = string.Empty;

            if(itemAdded)
            {
                result = type.ToString() + " added: " + item.ToString();
            }
            else
            {
                result = "ERROR! Item not added.";
            }
            return new TextContent(result);
        }

        public ITextContent Remove<T>(T item)
        {
            bool itemRemoved = false;

            Type type = typeof(T);
            if (type == typeof(string))
            {
                Strings.Remove(item as string);
                itemRemoved = true;
            }

            string result = string.Empty;

            if (itemRemoved)
            {
                result = type.ToString() + " removed: " + item.ToString();
            }
            else
            {
                result = "ERROR! Item not removed.";
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
