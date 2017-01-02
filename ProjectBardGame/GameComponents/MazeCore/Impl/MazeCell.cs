using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class MazeCell : IMazeCell
    {        
        public MazeCell(Maze Maze, int X, int Y)
        {
            _maze = Maze;
            _x = X;
            _y = Y;
            _northCarved = false;
            _westCarved = false;
        }
        public IMazeCell GetNeighbor(Direction Direction)
        {
            IMazeCell result = null;

            switch(Direction)
            {
                case Direction.North:
                    result = North;
                    break;
                case Direction.South:
                    result = South;
                    break;
                case Direction.East:
                    result = East;
                    break;
                case Direction.West:
                    result = West;
                    break;
            }

            return result;
        }

        public bool IsOpen(Direction Direction)
        {
            bool result = false;

            switch (Direction)
            {
                case Direction.North:
                    result = IsNorthOpen;
                    break;
                case Direction.South:
                    result = IsSouthOpen;
                    break;
                case Direction.East:
                    result = IsEastOpen;
                    break;
                case Direction.West:
                    result = IsWestOpen;
                    break;
            }

            return result;
        }

        public Direction? Adjacency(IMazeCell MazeCell)
        {
            Direction? result = null;

            bool sameX = MazeCell.X == X;
            bool sameY = MazeCell.Y == Y;
            if(sameX)
            {
                if(MazeCell.Y == Y-1)
                {
                    result = Direction.North;
                }
                if(MazeCell.Y == Y+1)
                {
                    result = Direction.South;
                }
            }
            if(sameY)
            {
                if(MazeCell.X == X-1)
                {
                    result = Direction.West;
                }
                if(MazeCell.X == X+1)
                {
                    result = Direction.East;
                }
            }

            return result;
        }

        public void CarveNorth()
        {
            _northCarved = true;
        }

        public void CarveSouth()
        {            
            if(South != null)
            {
                South.CarveNorth();
            }
        }

        public void CarveEast()
        {
            if(East != null)
            {
                East.CarveWest();
            }
        }

        public void CarveWest()
        {
            _westCarved = true;
        }

        public bool IsDirectionOpen(Direction Direction)
        {
            bool result = false;
            switch(Direction)
            {
                case Direction.North:
                    result = IsNorthOpen;
                    break;
                case Direction.South:
                    result = IsSouthOpen;
                    break;
                case Direction.East:
                    result = IsEastOpen;
                    break;
                case Direction.West:
                    result = IsWestOpen;
                    break;
            }
            return result;
        }

        public void CarveDirection(Direction Direction)
        {
            switch(Direction)
            {
                case Direction.North:
                    CarveNorth();
                    break;
                case Direction.South:
                    CarveSouth();
                    break;
                case Direction.East:
                    CarveEast();
                    break;
                case Direction.West:
                    CarveWest();
                    break;
            }
        }

        private readonly Maze _maze;
        private readonly int _x;
        private readonly int _y;
        private bool _northCarved;
        private bool _westCarved;

        public IMazeCell North
        {
            get
            {
                IMazeCell result = null;
                if(Y != 0)
                {
                    result = Maze.Cells[X, Y - 1];
                }
                return result;
            }
        }

        public IMazeCell South
        {
            get
            {
                IMazeCell result = null;
                if (Y != Maze.Height-1)
                {
                    result = Maze.Cells[X, Y + 1];
                }
                return result;
            }
        }

        public IMazeCell East
        {
            get
            {
                IMazeCell result = null;
                if (X != Maze.Width - 1)
                {
                    result = Maze.Cells[X + 1, Y];
                }
                return result;
            }
        }

        public IMazeCell West
        {
            get
            {
                IMazeCell result = null;
                if (X != 0)
                {
                    result = Maze.Cells[X - 1, Y];
                }
                return result;
            }
        }

        public IMazeCell[] NSEW
        {
            get
            {
                return new IMazeCell[] { North, South, East, West };
            }
        }

        public bool IsNorthOpen
        {
            get
            {
                bool result = false;
                if( Y != 0 && _northCarved)
                {
                    result = true;
                }                
                return result;
            }
        }

        public bool IsSouthOpen
        {
            get
            {
                bool result = false;
                if(South != null && South.IsNorthOpen)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool IsEastOpen
        {
            get
            {
                bool result = false;
                if(East != null && East.IsWestOpen)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool IsWestOpen
        {
            get
            {
                bool result = false;
                if(X != 0 && _westCarved)
                {
                    result = true;
                }
                return result;
            }
        }

        public bool[] IsNSEWOpen
        {
            get
            {
                return new bool[] { IsNorthOpen, IsSouthOpen, IsEastOpen, IsWestOpen };
            }
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public Maze Maze
        {
            get
            {
                return _maze;
            }
        }
    }
}
