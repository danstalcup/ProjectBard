using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public class GrowingTreeCarver : ICarver
    {
        public GrowingTreeCarver(IMaze Maze, IMazeCellSelector Selector, Random Randomizer)
        {
            _maze = Maze;
            _selector = Selector;
            _random = Randomizer;
            _activeCells = new List<IMazeCell>();
            IEnumerable<IMazeCell> allCellsTemp = _maze.Cells.Cast<IMazeCell>();
            _activeCells.Add(allCellsTemp.ElementAt(Randomizer.Next(allCellsTemp.Count())));
            _completeCells = new List<IMazeCell>();
        }

        public bool IsCarvingComplete
        {
            get
            {
                bool result = false;
                if(_activeCells.Count == 0)
                {
                    result = true;
                }
                return result;
            }
        }

        public IMaze Maze
        {
            get
            {
                return _maze;
            }
        }
        public void CarveAllSteps()
        {
            while(!IsCarvingComplete)
            {
                CarveStep();
            }
        }

        public void CarveStep()
        {
            if(IsCarvingComplete)
            {
                return;
            }

            IMazeCell nextCell = _selector.Select(_activeCells);
            int offset = _random.Next(4);
            IMazeCell[] nextCellNeighbers = nextCell.NSEW;
            List<IMazeCell> validNeighbors = new List<IMazeCell>();
            for(int i=0;i<4;i++)
            {
                int index = (i + offset) % 4;
                IMazeCell cell = nextCellNeighbers[index];
                if(cell != null && !_activeCells.Contains(cell) && !_completeCells.Contains(cell))
                {
                    validNeighbors.Add(cell);
                }
            }

            if(validNeighbors.Count == 0)
            {
                _activeCells.Remove(nextCell);
                _completeCells.Add(nextCell);
            }
            else
            {
                IMazeCell cellToAdd = validNeighbors.ElementAt(_random.Next(validNeighbors.Count));
                nextCell.CarveDirection(nextCell.Adjacency(cellToAdd).Value);
                _activeCells.Add(cellToAdd);
            }                                                       
        }

        public void CarveSteps(int Steps)
        {
            for (int i = 0; i < Steps; i++)
            {
                if (!IsCarvingComplete)
                {
                    CarveStep();
                }
            }
        }

        private IMaze _maze;
        private IMazeCellSelector _selector;
        private List<IMazeCell> _activeCells;
        private List<IMazeCell> _completeCells;        
        private Random _random;
    }
}
