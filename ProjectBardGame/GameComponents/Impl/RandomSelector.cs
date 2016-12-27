using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class RandomSelector : IMazeCellSelector
    {
        public RandomSelector(Random Random)
        {
            _random = Random;
        }
        public IMazeCell Select(IList<IMazeCell> Cells)
        {
            return Cells.ElementAt(_random.Next(0, Cells.Count));
        }


        private readonly Random _random;
    }
}
