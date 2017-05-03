using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersConversion.Services;
using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Services.Tests
{
    [TestClass()]
    public class MerchantsNotesIdentifierServiceTests
    {
        IMerchantsNotesIdentifierService merchantsNotesIdentifierService;
        public MerchantsNotesIdentifierServiceTests()
        {
            merchantsNotesIdentifierService = new MerchantsNotesIdentifierService();
        }

        [TestMethod()]
        public void DistributeInputTest()
        {
            string input = "glob is I";
            MerchantNote query = merchantsNotesIdentifierService.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(DirectMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest1()
        {
            string input = "glob glob Silver is 34 Credits";
            MerchantNote query = merchantsNotesIdentifierService.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(CreditItemMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest2()
        {
            string input = "how much is pish tegj glob glob ?";
            MerchantNote query = merchantsNotesIdentifierService.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(ItemCreditMappingQuery));
        }

        [TestMethod()]
        public void DistributeInputTest3()
        {
            string input = "how many Credits is glob prok Silver ?";
            MerchantNote query = merchantsNotesIdentifierService.DistributeInput(input);
            Assert.IsInstanceOfType(query, typeof(ItemCreditMappingQuery));
        }
    }
}