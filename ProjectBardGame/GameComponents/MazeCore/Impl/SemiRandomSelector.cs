using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class SemiRandomSelector : IMazeCellSelector
    {
        public SemiRandomSelector(Random Random, double RandomPercent)
        {
            _random = Random;
            _randomPercent = RandomPercent;
        }
        public IMazeCell Select(IList<IMazeCell> Cells)
        {
            IMazeCell result = null;
            if (_random.NextDouble() < _randomPercent)
            {
                result = Cells.ElementAt(_random.Next(0, Cells.Count));
            }
            else
            {
                result = Cells.Last();
            }
            return result;
        }


        private readonly Random _random;
        private readonly double _randomPercent;
    }
}
