using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;
using ProjectBard.Simple;
using ProjectBardGame.GameComponents;

namespace ProjectBardGame.GameEngine
{
    public class MazeGenState : IState
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
                            "autocarve",
                            "autocarve [steps]",
                            "autocarve all"
                        }
                    );
            }
        }

        public IResult Process(ICommand Command)
        {
            IResult result = null;
            switch (Command.CommandString)
            {
                case "newmaze":
                    {
                        result = NewMaze(Command);
                        break;
                    }
                case "autocarve":
                    {
                        result = CarveMaze(Command);
                        break;
                    }
                case "setautocarver":
                    {
                        result = SetAutocarver(Command);
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
        private IMazeCellSelector _selector;            

        private IResult CarveMaze(ICommand Command)
        {
            IResult result;
            if (Command.Arguments.Count == 0)
            {
                _carver.CarveStep();
            }
            else if (Command.Arguments[0] == "all")
            {
                _carver.CarveAllSteps();
            }
            else
            {
                _carver.CarveSteps(int.Parse(Command.Arguments[0]));
            }
            result = MazeFactories.MazeResult(Command, this, true);
            return result;
        }

        private IResult NewMaze(ICommand Command)
        {
            IResult result;
            int width = int.Parse(Command.Arguments[0]);
            int height = int.Parse(Command.Arguments[1]);

            _selector = new NewestSelector();
            if (Command.Arguments.Count > 2)
            {
                if (Command.Arguments.Contains("random"))
                {
                    _selector = new RandomSelector(new Random());
                }
            }

            _maze = new Maze(width, height);

            //future: customize carver here?
            _carver = new GrowingTreeCarver(_maze, new NewestSelector(), new Random());

            result = MazeFactories.MazeResult(Command, this, true);
            return result;
        }

        private IResult SetAutocarver(ICommand command)
        {
            IResult result = ResultFactories.EmptyResult(command, this);

            if(command.Arguments.Count == 0)
            {
                throw new ArgumentException("Argument required!");
            }

            bool switchMade = true;

            switch(command.Arguments[0])
            {
                case "random":
                    SetRandomSelector(command);
                    break;
                case "newest":
                    _selector = new NewestSelector();
                    break;
                case "semirandom":
                    SetSemiRandomSelector(command);
                    break;
                default:
                    switchMade = false;
                    break;
            }


            return result;
        }

        private void SetSemiRandomSelector(ICommand command)
        {        
            if (command.Arguments.Count == 1)
            {
                throw new ArgumentException("Random selection percentage required for semirandom selector (0.00-1.00)!");
            }
            if (command.Arguments.Count > 2)
            {
                _selector = new SemiRandomSelector(new Random(), double.Parse(command.Arguments[1]));
            }
            else
            {
                _selector = new SemiRandomSelector(new Random(int.Parse(command.Arguments[2])), double.Parse(command.Arguments[1]));
            }
        }

        private void SetRandomSelector(ICommand command)
        {
            if (command.Arguments.Count > 1)
            {
                _selector = new RandomSelector(new Random(int.Parse(command.Arguments[1])));
            }
            else
            {
                _selector = new NewestSelector();
            }
        }
    }
}
