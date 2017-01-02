using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBardGame.GameComponents
{
    public interface IMaze
    {
        IMazeCell[,] Cells { get; }
        int Height { get; }
        int Width { get; }
        ITextContent Display { get; }
        ICollection<IMazeAgentPosition> AgentPositions { get; }
        ICollection<IMazeAgent> Agents { get; }   
    }
}
