using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverGabeEvo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverGabeEvo.Tests
{
    [TestClass()]
    public class RoverTests
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Plateau.setSize(5, 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(RoverPositionException))]
        public void RoverInvalidWidthTest()
        {
            new Rover(-1, 5, "N", 1);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(RoverPositionException))]
        public void RoverInvalidHeightTest()
        {
            new Rover(5, -1, "N", 1);
            Assert.Fail();
        }

        [TestMethod()]
        public void moveValidTest()
        {
            Rover test = new Rover(3, 3, "N", 1);
            test.move();
            string expectedResult = "3 4 N";
            Assert.AreEqual(expectedResult, test.ToString());
        }

        [TestMethod()]
        public void moveEdgeTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            test.move();
            string expectedResult = "5 5 N";
            Assert.AreEqual(expectedResult, test.ToString());
        }

        [TestMethod()]
        public void turnLeftTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            test.turnLeft();
            string expectedResult = "5 5 W";
            Assert.AreEqual(expectedResult, test.ToString());
        }

        [TestMethod()]
        public void turnRightTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            test.turnRight();
            string expectedResult = "5 5 E";
            Assert.AreEqual(expectedResult, test.ToString());
        }

        [TestMethod()]
        public void executeInstructionsTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            test.executeInstructions("LLM");
            string expectedResult = "5 4 S";
            Assert.AreEqual(expectedResult, test.ToString());
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void executeInvalidInstructionsTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            test.executeInstructions("LLC");
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Rover test = new Rover(5, 5, "N", 1);
            string expectedResult = "5 5 N";
            Assert.AreEqual(expectedResult, test.ToString());
        }
    }
}