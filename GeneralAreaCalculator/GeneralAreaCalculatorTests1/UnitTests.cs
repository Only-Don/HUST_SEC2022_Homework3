using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeneralAreaCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralAreaCalculator.Tests
{
    [TestClass()]
    public class UnitTests
    {
        [TestMethod()]
        public void UnitTest()
        {
            Unit unit = new Unit(15, 20, true, false);
            Assert.IsTrue(unit.centimeterLeft.centimeter == 15);
            Assert.IsTrue(unit.centimeterRight.centimeter == 20 * 2.54);
            Assert.IsTrue(unit.inchLeft.inch == 15 / 2.54);
            Assert.IsTrue(unit.inchRight.inch == 20);
        }

        [TestMethod()]
        public void UnitTest_TwoParam()
        {
            Unit unit = new Unit(15, false);
            Assert.IsTrue(unit.centimeterLeft.centimeter == 15 * 2.54);
            Assert.IsNull(unit.centimeterRight);
            Assert.IsTrue(unit.inchLeft.inch == 15);
            Assert.IsNull(unit.inchRight);
        }
    }
}