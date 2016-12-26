using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBardGame.GameComponents
{
    public interface ICarver
    {
        IMaze Maze { get; }
        void CarveStep();
        void CarveSteps(int Steps);
        void CarveAllSteps();
        bool IsCarvingComplete { get; }
    }
}
