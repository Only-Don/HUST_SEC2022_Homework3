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
    public class CentimeterTests
    {
        [TestMethod()]
        public void CentimeterTest()
        {
            Centimeter centimeter = new Centimeter(15, false);
            Assert.IsTrue(centimeter.centimeter == 15 * 2.54);
        }
    }
}