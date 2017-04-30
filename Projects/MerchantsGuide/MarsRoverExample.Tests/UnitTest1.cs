using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverExample.Domain;

namespace MarsRoverExample.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckChangeDirection1()
        {
            Direction d = Direction.East;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Left);
            Assert.AreEqual(Direction.North, newd, $"New d is {newd}");
        }

        [TestMethod]
        public void CheckChangeDirection2()
        {
            Direction d = Direction.South;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Left);
            Assert.AreEqual(Direction.East, newd, $"New d is {newd}");
        }

        [TestMethod]
        public void CheckChangeDirection3()
        {
            Direction d = Direction.West;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Left);
            Assert.AreEqual(Direction.South, newd, $"New d is {newd}");
        }

        [TestMethod]
        public void CheckChangeDirection4()
        {
            Direction d = Direction.East;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Right);
            Assert.AreEqual(Direction.South, newd, $"New d is {newd}");
        }

        [TestMethod]
        public void CheckChangeDirection5()
        {
            Direction d = Direction.South;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Right);
            Assert.AreEqual(Direction.West, newd, $"New d is {newd}");
        }

        [TestMethod]
        public void CheckChangeDirection6()
        {
            Direction d = Direction.West;
            Direction newd = d.ChangeDirection(ChangeDirectionBy.Right);
            Assert.AreEqual(Direction.North, newd, $"New d is {newd}");
        }
    }
}
