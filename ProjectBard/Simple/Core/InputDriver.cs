using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class InputDriver : IInputDriver
    {
        public InputDriver()
        {
            _observers = new List<IObserver<ICommand>>();
        }

        public void Open()
        {
            while(true)
            { 
                var input = string.Empty;

                do
                {
                    Console.Write(">");
                    input = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(input));
            

                var inputParameters = input.Trim().Split(' ').ToList();

                var firstParameter = inputParameters[0].ToLower();

                inputParameters.RemoveAt(0);

                var command = new Command
                {
                    CommandString = firstParameter,
                    Arguments = inputParameters
                };

                foreach(var observer in _observers)
                {
                    observer.OnNext(command);
                }
            }
        }

        public IDisposable Subscribe(IObserver<ICommand> observer)
        {
            _observers.Add(observer);
            return this;
        }

        public void Dispose()
        {
            _observers = null;
        }

        private List<IObserver<ICommand>> _observers;
    }
}
