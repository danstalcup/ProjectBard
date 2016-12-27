using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.SimpleEngine;
using ProjectBardGame.GameComponents;

namespace ProjectBardGame.GameEngine
{
    public class MazeState : IState
    {
        public IState ReturnState
        {
            get; set;
        }

        public ITextContent StateDescription
        {
            get
            {
                return _maze.Display;
            }
        }

        public ITextContent ValidCommands
        {
            get
            {
                        return TextContentFactories.EligibleCommands(new List<string>
                        {
                            "newmaze [width] [height]",
                            "carvemaze",
                            "carvemaze [steps]",
                            "carvemaze all"
                        }
                    );
            }
        }

        public IResult Process(ICommand Command)
        {
            IResult result = null;
            switch (Command.Command)
            {
                case "newmaze":
                    {                        
                        int width = int.Parse(Command.Arguments[0]);
                        int height = int.Parse(Command.Arguments[1]);

                        IMazeCellSelector selector = new NewestSelector();
                        if(Command.Arguments.Count > 2)
                        {
                            switch(Command.Arguments[2])
                            {
                                case "random":
                                    selector = new RandomSelector(new Random());
                                    break;
                            }
                        }

                        _maze = new Maze(width, height);

                        //future: customize carver here?
                        _carver = new GrowingTreeCarver(_maze, new NewestSelector(), new Random());

                        result = MazeFactories.MazeResult(Command, this,true);
                        break;
                    }
                case "carvemaze":
                    {
                        if(Command.Arguments.Count == 0)
                        {
                            _carver.CarveStep();
                        }
                        else if(Command.Arguments[0] == "all")
                        {
                            _carver.CarveAllSteps();
                        }
                        else
                        {
                            _carver.CarveSteps(int.Parse(Command.Arguments[0]));
                        }
                        result = MazeFactories.MazeResult(Command, this, true);
                        break;
                    }
                default:
                    {
                        result = ResultFactories.EmptyResult(Command, this);
                        break;
                    }
            }

            return result;
        }

        public IMaze Maze
        {
            get
            {
                return _maze;
            }
        }

        private Maze _maze;
        private ICarver _carver;
    }
}
