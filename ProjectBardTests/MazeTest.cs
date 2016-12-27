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
        public void EmptyMazeDisplay()
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

        [TestMethod]
        public void CarvedMaze()
        {
            Maze maze = new Maze(5, 5);
            GrowingTreeCarver carver = new GrowingTreeCarver(maze, new NewestSelector(), new Random());
            carver.CarveAllSteps();

            ITextContent output = maze.Display;            
        }
    }
}
