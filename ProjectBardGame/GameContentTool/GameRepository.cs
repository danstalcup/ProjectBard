using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Content;
using ProjectBard.Framework;

using ProjectBardGame.GameComponents;

namespace ProjectBardGame.GameContentTool
{
    public class GameRepository : Repository
    {
        public List<Maze> Mazes { get; set; }

        public override void Initialize()
        {
            Mazes = new List<Maze>();
        }        
    }
}
