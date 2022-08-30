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
    public class AreaTests
    {
        [TestMethod()]
        public void Area_zheng_Test()
        {
            double a = 1.1;
            double b = 2.2;
            int gragh_zheng = 0;
            double result_expected_cm = 1.1 * 1.1;
            double result_expected_in = 2.2 * 2.2;
            Area aa = new Area(a, b, gragh_zheng);
            Assert.IsTrue((result_expected_cm == aa.cmArea) && (result_expected_in == aa.inArea));
        }

        [TestMethod()]
        public void Area_yuan_Test()
        {
            double a = 1.1;
            double b = 2.2;
            int gragh_yuan = 1;
            double result_expected_cm = 1.1 * 1.1 * 3.1415926 / 4;
            double result_expected_in = 2.2 * 2.2 * 3.1415926 / 4;
            Area aa = new Area(a, b, gragh_yuan);
            Assert.IsTrue((result_expected_cm == aa.cmArea) && (result_expected_in == aa.inArea));
        }

        [TestMethod()]
        public void Area_chang_Test()
        {
            double a = 1.1;
            double b = 2.2;
            double c = 3.1;
            double d = 4.1;
            int gragh_chang = 2;
            double result_expected_cm = 1.1 * 3.1;
            double result_expected_in = 2.2 * 4.1;
            Area aa = new Area(a, b, c, d, gragh_chang);
            Assert.IsTrue((result_expected_cm == aa.cmArea) && (result_expected_in == aa.inArea));
        }

        [TestMethod()]
        public void Area_san_Test()
        {
            double a = 1.1;
            double b = 2.2;
            double c = 3.1;
            double d = 4.1;
            int gragh_san = 3;
            double result_expected_cm = 1.1 * 3.1 / 2;
            double result_expected_in = 2.2 * 4.1 / 2;
            Area aa = new Area(a, b, c, d, gragh_san);
            Assert.IsTrue((result_expected_cm == aa.cmArea) && (result_expected_in == aa.inArea));
        }
    }
}