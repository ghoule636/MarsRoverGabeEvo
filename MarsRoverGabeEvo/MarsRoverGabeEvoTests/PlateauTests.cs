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
    public class PlateauTests
    {
        [TestMethod()]
        [ExpectedException(typeof(PlateauSizeException))]
        public void setInvalidWidthSizeTest()
        {
            Plateau.setSize(-1, 5);
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(PlateauSizeException))]
        public void setInvalidHeightSizeTest()
        {
            Plateau.setSize(5, -1);
            Assert.Fail();
        }


        [TestMethod()]
        public void getHeightTest()
        {
            Plateau.setSize(5, 5);
            Assert.AreEqual(5, Plateau.getHeight());
        }

        [TestMethod()]
        public void getWidthTest()
        {
            Plateau.setSize(5, 5);
            Assert.AreEqual(5, Plateau.getWidth());
        }
    }
}