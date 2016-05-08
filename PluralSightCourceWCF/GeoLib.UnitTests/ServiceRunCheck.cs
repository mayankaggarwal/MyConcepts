using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using GeoLib.Services;
using GeoLib.Contracts;
using System.Collections.Generic;
using System.Linq;
using GeoLib.Data;

namespace GeoLib.UnitTests
{
    [TestClass]
    public class ServiceRunCheck
    {
        [TestMethod]
        public void GetStatesCheck()
        {
            IGeoService geoManager = new GeoManager();
            List<string> result = geoManager.GetStates(true).ToList();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void Check_Get_Zip_Data()
        {
            Mock<IZipCodeRepository> moqZipRepository = new Mock<IZipCodeRepository>();

            ZipCode zipCode = new ZipCode
            {
                Zip = "122001",
                City = "Gurgaon",
                State = new State
                {
                    Abbreviation = "HRY"
                }
            };

            moqZipRepository.Setup(obj => obj.GetByZip("122001")).Returns(zipCode);

            IGeoService geoService = new GeoManager(moqZipRepository.Object);
            ZipCodeData zipCodeData = geoService.GetZipInfo("122001");

            Assert.IsTrue(zipCodeData.City.ToUpper().Equals("GURGAON"));
            Assert.IsTrue(zipCodeData.State.ToUpper().Equals("HRY"));
          
        }
    }
}
