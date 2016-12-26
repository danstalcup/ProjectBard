using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ProjectBardGame.GameComponents;
using ProjectBard.Framework;
using ProjectBard.SimpleEngine;

namespace ProjectBardTests
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void EmptyMazeDisplayTest()
        {            
            Maze maze = new Maze(3,3);
            ITextContent output = maze.Display;

            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual("███████", output.ContentLines[2 * i]);
                Assert.AreEqual("█ █ █ █", output.ContentLines[2 * i + 1]);
            }

            Assert.AreEqual("███████", output.ContentLines[6]);
        }
    }
}
