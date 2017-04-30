using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersConversion.engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.engines.Tests
{
    [TestClass()]
    public class RomanConversionEngineTests
    {
        [TestMethod()]
        public void ConvertToIntTest()
        {
            string input = "II";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(2, result);
        }

        [TestMethod()]
        public void ConvertToIntTest2()
        {
            string input = "IV";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(4, result);
        }

        [TestMethod()]
        public void ConvertToIntTest3()
        {
            string input = "XX";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(20, result);
        }

        [TestMethod()]
        public void ConvertToIntTest4()
        {
            string input = "XLII";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(42, result);
        }

        [TestMethod()]
        public void ConvertToIntTest5()
        {
            string input = "MCMIII";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(1903, result);
        }

        [TestMethod()]
        public void ConvertToIntTest7()
        {
            string input = "MMVI ";
            int result = RomanConversionEngine.ConvertToInt(input);
            Assert.AreEqual(2006, result);
        }
    }
}