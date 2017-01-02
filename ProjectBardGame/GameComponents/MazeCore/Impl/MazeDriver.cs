using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class MazeDriver : IMazeDriver
    {
        public MazeDriver(Maze Maze)
        {
            _maze = Maze;
        }
        public IMaze Maze
        {
            get
            {
                return _maze;
            }
        }

        private Maze _maze;
    }
}
