using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersConversion.engines;
using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.engines.Tests
{
    [TestClass()]
    public class UserInputRegistrarTests
    {
        [TestMethod()]
        public void DistributeInputTest()
        {
            string input = "glob is I";
            Query query = UserInputRegistrar.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(DirectMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest1()
        {
            string input = "glob glob Silver is 34 Credits";
            Query query = UserInputRegistrar.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(CreditItemMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest2()
        {
            string input = "how much is pish tegj glob glob ?";
            Query query = UserInputRegistrar.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(ItemCreditMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest3()
        {
            string input = "how many Credits is glob prok Silver ?";
            Query query = UserInputRegistrar.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(ItemCreditMappingQuery));
        }
    }
}