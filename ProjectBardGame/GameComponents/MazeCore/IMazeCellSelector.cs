using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public interface IMazeCellSelector
    {
        IMazeCell Select(IList<IMazeCell> Cells);
    }
}
