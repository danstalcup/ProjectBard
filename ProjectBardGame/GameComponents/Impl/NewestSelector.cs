using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class NewestSelector : IMazeCellSelector
    {
        public IMazeCell Select(IList<IMazeCell> Cells)
        {
            IMazeCell result = null;
            if(Cells.Count > 0)
            {
                result = Cells.Last();
            }
            return result;
        }
    }
}
