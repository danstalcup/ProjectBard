using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class ConEngine : IEngine
    {
        public ConEngine(IState StartState, IContentTool ContentTool)
        {
            Input = new ConsoleInputDriver();
            Output = new ConsoleOutputDriver();
            _observers = new List<IObserver<IResult>>();
            Subscribe(Output);
            Input.Subscribe(this);
            _result = ResultFactories.EmptyResult(CommandFactories.StartCommand(), StartState);
            _state = StartState;
            this.ContentTool = ContentTool;
            HasContentToolPermission = true;
            Input.Open();
        }        

        public IResult Process(ICommand Command)
        {
            IResult result = null;
            string coreCommand = Command.Command.Trim();
            if(coreCommand == "help")
            {
                result = ResultFactories.HelpResult(Command, CurrentState);
            }
            else if (coreCommand == "commands")
            {
                result = ResultFactories.CommandsResult(Command, CurrentState);
            }
            else if (coreCommand == "state")
            {
                result = ResultFactories.CurrentStateResult(Command, CurrentState);
            }
            else if (coreCommand == "exitgame")
            {
                Environment.Exit(0);
            }
            else if (coreCommand == "content")
            {
                if(HasContentToolPermission)
                {
                    ContentTool.ReturnState = CurrentState;
                    result = ResultFactories.StateChangedResult(Command, ContentTool, new TextContent("Activating Content Tool."), new TextContent("Type in a command for the Content Tool."));
                }
            }
            else
            {
                result = CurrentState.Process(Command);
            }
            if(result.StateChanged)
            {
                _state = result.ResultingState;
            }
            return result;            
        }

        public void Step()
        {            
            // Output.Show(LatestResult.NextPrompt);
            // var nextCommand = Input.GetNextCommand();
            // var result = Process(nextCommand);
            // Output.Show(result.ResultDetails);            
            // UpdateLatestResultAndCurrentState(result);
        }

        private void UpdateLatestResultAndCurrentState(IResult result)
        {
            _result = result;
            if (result.StateChanged)
            {
                _state = result.ResultingState;
            }
        }

        public IDisposable Subscribe(IObserver<IResult> observer)
        {
            _observers.Add(observer);
            return this;
        }

        public void OnNext(ICommand value)
        {
            var result = Process(value);
            foreach(var observer in _observers)
            {
                observer.OnNext(result);
            }
        }

        public void OnError(Exception error)
        {
            foreach (var observer in _observers)
            {
                observer.OnError(error);
            }
        }

        public void OnCompleted()
        {
            return;
        }

        public void Dispose()
        {
            _observers = null;
        }

        public IState CurrentState
        {
            get
            {
                return _state;
            }
        }

        public bool IsEngineActive
        {
            get
            {
                return true;
            }
        }

        public IResult LatestResult
        {
            get
            {
                return _result;
            }            
        }

        public IInputDriver Input
        {
            get; set;
        }

        public IOutputDriver Output
        {
            get; set;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Title cannot be empty.");
                }
                else
                {
                    _title = value.Trim();
                    Console.Title = _title;
                }                
            }
        }

        public bool HasContentToolPermission
        {
            get; set;
        }

        public IContentTool ContentTool { get; set; }        

        private IState _state;

        private IResult _result;

        private string _title;

        private List<IObserver<IResult>> _observers;
    }

}
