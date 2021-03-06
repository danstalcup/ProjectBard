﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;

using ProjectBardGame.GameComponents;

using Newtonsoft.Json;

namespace ProjectBardGame.GameContent
{
    public class GameRepository : IRepository
    {
        public List<Maze> Mazes { get; set; }

        public virtual void Initialize()
        {
            Mazes = new List<Maze>();
        }

        public string Serialize(string Entity)
        {
            string result = string.Empty;
            switch (Entity)
            {
                case "maze":
                    {
                        result = Serialize<Maze>();
                        break;
                    }
            }
            return result;
        }

        public void Deserialize(string Entity, string Json)
        {
            switch (Entity)
            {
                case "maze":
                    {
                        Deserialize<Maze>(Json);
                        break;
                    }
            }
        }

        public ITextContent Add(string Entity, object Item)
        {
            ITextContent result = new TextContent();
            switch (Entity)
            {
                case "maze":
                    {
                        result = Add((Maze)Item);
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
                case "maze":
                    {
                        result = Remove((Maze)Item);
                        break;
                    }
            }
            return result;
        }

        public IList<object> GetContent(string Entity)
        {
            IList <object> result = new List<object>();

            if(Entity == "maze")
            {
                result = Mazes.Select(m => (object)m).ToList();
            }
            
            return result;
        }

        public IList<T> GetContent<T>()
        {
            IList<T> result = new List<T>();
            Type type = typeof(T);
            if (type == typeof(Maze))
            {
                result = Mazes as List<T>;
            }
            return result;
        }

        public string Serialize<T>()
        {
            string result = string.Empty;
            Type type = typeof(T);
            if (type == typeof(Maze))
            {
                result = JsonConvert.SerializeObject(Mazes);
            }
            return result;
        }

        public void Deserialize<T>(string Json)
        {
            Type type = typeof(T);
            if (type == typeof(Maze))
            {
                Mazes = JsonConvert.DeserializeObject<List<Maze>>(Json);
            }
        }

        public ITextContent Add<T>(T item)
        {
            bool itemAdded = false;

            Type type = typeof(T);
            if (type == typeof(Maze))
            {
                Maze maze = item as Maze;
                maze.ID = GetNextID<Maze>();
                Mazes.Add(maze);
                itemAdded = true;
            }

            string result = string.Empty;

            if (itemAdded)
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
            if (type == typeof(Maze))
            {
                Mazes.Remove(item as Maze);
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
            IList<object> result = new List<object>();
            switch (Entity.ToLower())
            {
                case "maze":
                    result = (IList<object>)GetContent<Maze>() ;
                    break;
            }
            return result;
        }

        public int GetNextID(string Entity)
        {
            int result = 0;

            if (Entity == "maze")
            {
                result = GetNextID<Maze>();
            }

            return result;
        }

        public int GetNextID<E>() where E : IContentEntity
        {
            int result = 0;

            Type type = typeof(E);

            if(type == typeof(Maze))
            {
                result = (Mazes.Max(m => m.ID as int?) ?? 0) + 1;
            }

            return result;
        }
    }
}
