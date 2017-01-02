using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.Simple
{
    public class OutputDriver : IOutputDriver
    {
        public void OnCompleted()
        {
            return;
        }

        public void OnError(Exception error)
        {
            Show(new TextContent($"EXCEPTION: {error.Message}"));
        }

        public void OnNext(IResult value)
        {
            Show(value.ResultDetails);
            Show(value.NextPrompt);
        }

        public void Show(ITextContent Text)
        {
            foreach(var line in Text.ContentLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();
        }
    }
}
