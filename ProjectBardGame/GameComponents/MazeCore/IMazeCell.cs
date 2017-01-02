using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public interface IMazeCell
    {
        IMazeCell North { get; }
        IMazeCell South { get; }
        IMazeCell East { get; }
        IMazeCell West { get; }
        IMazeCell[] NSEW { get; }
        IMazeCell GetNeighbor(Direction Direction);
        bool IsNorthOpen { get; }
        bool IsSouthOpen { get; }
        bool IsEastOpen { get; }
        bool IsWestOpen { get; }
        bool[] IsNSEWOpen { get; }
        bool IsDirectionOpen(Direction Direction);
        void CarveNorth();
        void CarveSouth();
        void CarveEast();
        void CarveWest();
        void CarveDirection(Direction Direction);

        int X { get; }
        int Y { get; }
        Maze Maze { get; }
        bool IsOpen(Direction Direction);
        Direction? Adjacency(IMazeCell MazeCell);

    }
}
