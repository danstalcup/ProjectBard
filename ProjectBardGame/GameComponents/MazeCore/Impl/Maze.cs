using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectBard.Framework;
using ProjectBard.Simple;

namespace ProjectBardGame.GameComponents
{
    public class Maze : IMaze
    {
        public Maze(int Width, int Height)
        {
            _width = Width;
            _height = Height;
            _cells = new MazeCell[Width, Height];
            for(int i=0; i<Width; i++)
            {
                for(int j=0; j<Height; j++)
                {
                    _cells[i, j] = new MazeCell(this, i, j);
                }
            }
        }
        public IMazeCell[,] Cells
        {
            get
            {
                return _cells;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public ITextContent Display
        {
            get
            {
                List<string> result = new List<string>();

                int displayWidth = Width * 2;
                int displayHeight = Height * 2;

                for(int j=0; j<displayHeight; j++)
                {
                    StringBuilder line = new StringBuilder();
                    bool evenRow = j % 2 == 0;
                    int cellRow = j / 2;

                    for(int i=0; i<displayWidth; i++)
                    {
                        int cellCol = i / 2;
                        bool isOpen = false;
                        
                        bool evenCol = i % 2 == 0;

                        if(evenRow)
                        {
                            if(evenCol)
                            {
                                isOpen = false;
                            }
                            else
                            {
                                isOpen = Cells[cellCol, cellRow].IsNorthOpen;
                            }
                        }
                        else
                        {
                            if(evenCol)
                            {
                                isOpen = Cells[cellCol, cellRow].IsWestOpen;
                            }
                            else
                            {
                                isOpen = true;
                            }
                        }

                        string cellString = string.Empty;
                        if (isOpen)
                        {
                            cellString = " ";
                        }
                        else
                        {
                            cellString = "\u2588";
                        }

                        line.Append(cellString);
                    }
                    line.Append("\u2588");                                                                          
                    result.Add(line.ToString());
                }
                result.Add(new String('\u2588', displayWidth+1));
                return new TextContent(result);
            }
        }

        public ICollection<IMazeAgentPosition> AgentPositions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICollection<IMazeAgent> Agents
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private int _width;
        private int _height;

        private MazeCell[,] _cells;        
    }
}
