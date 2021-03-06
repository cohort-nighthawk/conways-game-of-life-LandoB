﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife;

namespace GameOfLifeTest
{
    [TestClass]
    public class UnitTestWorld
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMinimumWorldSize()
        {
            World myWorld = new World(0);
        }

        [TestMethod]
        public void TestWorldConstructorDefault()
        {
            World myWorld = new World(10);
            Assert.IsFalse(myWorld.CurrentWorld[0, 0].IsAlive);
            Assert.IsFalse(myWorld.CurrentWorld[0, 0].NextGeneration);
        }
    }
}
