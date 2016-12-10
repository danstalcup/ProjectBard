using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ProjectBard.Framework;

namespace ProjectBard.SimpleEngine
{
    public class TextContent : ITextContent
    {
        public TextContent()
        {
            this.Content = string.Empty;
        }        

        public TextContent(string Content)
        {
            this.Content = Content;
        }

        public TextContent(IList<string> ContentLines)
        {
            this.ContentLines = ContentLines;
        }

        public string Content
        {
            get
            {
                return string.Join("\n", ContentLines);
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    ContentLines = value.Split('\n').ToList();
                }
                else
                {
                    ContentLines = new List<string> { };
                }                
            }
        }

        public IList<string> ContentLines
        {
            get;set;
        }

        public ITextContent Append(ITextContent Text)
        {
            foreach(var line in Text.ContentLines)
            {
                ContentLines.Add(line);
            }
            return this;
        }

        public ITextContent AppendLine(string Line)
        {
            ContentLines.Add(Line);
            return this;
        }

        public ITextContent AppendLines(List<string> Lines)
        {
            foreach (var line in Lines)
            {
                ContentLines.Add(line);
            }
            return this;
        }

        public static implicit operator TextContent (string Text)
        {
            return new TextContent(Text);
        }
    }
}
