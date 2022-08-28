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
    public class InchTests
    {
        [TestMethod()]
        public void InchTest()
        {
            Inch inch = new Inch(15, true);
            Assert.IsTrue(inch.inch == 15 / 2.54);
        }
    }
}