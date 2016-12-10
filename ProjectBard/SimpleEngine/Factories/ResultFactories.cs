using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class ResultFactories
    {
        public static Result EmptyResult(ICommand Command, IState State)
        {
            return new Result
            {
                InitializingCommand = Command,
                NextPrompt = new TextContent(),
                ResultDetails = new TextContent(),
                StateChanged = false,
                ResultingState = State
            };
        }

        public static Result InformationalResult(ICommand Command, IState State, ITextContent ResultDetails, ITextContent NextPrompt)
        {
            Result Result = EmptyResult(Command,State);
            Result.NextPrompt = NextPrompt;
            Result.ResultDetails = ResultDetails;
            return Result;
        }                    

        public static Result StateChangedResult(ICommand Command, IState State, ITextContent ResultDetails, ITextContent NextPrompt)
        {
            Result Result = InformationalResult(Command, State, ResultDetails, NextPrompt);
            Result.StateChanged = true;
            return Result;
        }

        public static Result HelpResult(ICommand Command, IState State)
        {
            return InformationalResult(Command, State,

                new TextContent(new List<string> {
                    "Welcome to Project Bard v0.02",
                    string.Empty,
                    "At any time, the following commands are valid:",
                    "help - Repeate these instructions.",
                    "commands - See a list of currently valid commands.",
                    "state - See the current state of the program.",
                    "exitgame - Exit the program.",
                    }),


                new TextContent("Type a command, or \"help\" to repeate the instructions")

                );
        }

        public static Result CommandsResult(ICommand Command, IState State)
        {
            return InformationalResult(Command, State,

                State.ValidCommands,


                new TextContent("Type a command to continue")

                );
        }

        public static Result CurrentStateResult(ICommand Command, IState State)
        {
            return InformationalResult(Command, State,

                State.StateDescription,


                new TextContent("Type a command to continue")

                );
        }
    }
}
