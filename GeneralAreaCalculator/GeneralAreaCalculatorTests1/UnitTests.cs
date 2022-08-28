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
            Centimeter centimeterLeft = new Centimeter(15, true);
            Centimeter centimeterRight = new Centimeter(20, false);
            Inch inchLeft = new Inch(15, true);
            Inch inchRight = new Inch(20, false);
            Assert.IsTrue(unit.centimeterLeft.centimeter == centimeterLeft.centimeter);
            Assert.IsTrue(unit.centimeterRight.centimeter == centimeterRight.centimeter);
            Assert.IsTrue(unit.inchLeft.inch == inchLeft.inch);
            Assert.IsTrue(unit.inchRight.inch == inchRight.inch);
        }

        [TestMethod()]
        public void UnitTest_TwoParam()
        {
            Unit unit = new Unit(15, false);
            Centimeter centimeterLeft = new Centimeter(15, false);
            Inch inchLeft = new Inch(15, false);
            Assert.IsTrue(unit.centimeterLeft.centimeter == centimeterLeft.centimeter);
            Assert.IsNull(unit.centimeterRight);
            Assert.IsTrue(unit.inchLeft.inch == inchLeft.inch);
            Assert.IsNull(unit.inchRight);
        }
    }
}