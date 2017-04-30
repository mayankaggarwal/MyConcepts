using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumbersConversion.Domain;
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
    public class MapQueriesTests
    {
        [TestMethod()]
        public void MapUnitTest()
        {
            DirectMappingQuery query = new DirectMappingQuery("glob is I");
            IntergalacticUnit interglacticUnit = MapQueries.MapUnit(query);
            Assert.IsNotNull(interglacticUnit);
        }

        [TestMethod()]
        public void MapUnitTest1()
        {
            DirectMappingQuery query = new DirectMappingQuery("prok is V");
            IntergalacticUnit interglacticUnit = MapQueries.MapUnit(query);
            Assert.IsNotNull(interglacticUnit);
        }

        [TestMethod()]
        public void MapUnitTest2()
        {
            DirectMappingQuery query = new DirectMappingQuery("pish is X");
            IntergalacticUnit interglacticUnit = MapQueries.MapUnit(query);
            Assert.IsNotNull(interglacticUnit);
        }

        [TestMethod()]
        public void MapUnitTest3()
        {
            DirectMappingQuery query = new DirectMappingQuery("tegj is L");
            IntergalacticUnit interglacticUnit = MapQueries.MapUnit(query);
            Assert.IsNotNull(interglacticUnit);
        }

        [TestMethod()]
        public void MapMetalTest()
        {
            List<IntergalacticUnit> lstIntergalacticUnits = new List<IntergalacticUnit>();
            lstIntergalacticUnits.AddRange(GetIntergalacticUnits(GetDirectMappingQueries()));

            Query creditItemQuery = new CreditItemMappingQuery("glob glob Silver is 34 Credits");
            Metal metal = MapQueries.MapMetal((CreditItemMappingQuery)creditItemQuery, lstIntergalacticUnits);
            Assert.IsNotNull(metal);
            Assert.AreEqual(17, metal.MetalValue);
        }

        [TestMethod()]
        public void MapMetalTest1()
        {
            List<IntergalacticUnit> lstIntergalacticUnits = new List<IntergalacticUnit>();
            lstIntergalacticUnits.AddRange(GetIntergalacticUnits(GetDirectMappingQueries()));

            Query creditItemQuery = new CreditItemMappingQuery("glob prok Gold is 57800 Credits");
            Metal metal = MapQueries.MapMetal((CreditItemMappingQuery)creditItemQuery, lstIntergalacticUnits);
            Assert.IsNotNull(metal);
            Assert.AreEqual(14450, metal.MetalValue, metal.MetalValue);
        }

        [TestMethod()]
        public void MapMetalTest2()
        {
            List<IntergalacticUnit> lstIntergalacticUnits = new List<IntergalacticUnit>();
            lstIntergalacticUnits.AddRange(GetIntergalacticUnits(GetDirectMappingQueries()));
            Query creditItemQuery = new CreditItemMappingQuery("pish pish Iron is 3910 Credits");
            Metal metal = MapQueries.MapMetal((CreditItemMappingQuery)creditItemQuery, lstIntergalacticUnits);
            Assert.IsNotNull(metal);
            Assert.AreEqual(185.5, metal.MetalValue, metal.MetalValue);
        }

        [TestMethod()]
        public void MapQueriesToCreditsTest()
        {
            List<Metal> lstMetals = new List<Metal>();
            lstMetals.AddRange(GetMetals(GetCreditItemMappingQueries(GetIntergalacticUnits(GetDirectMappingQueries())), GetIntergalacticUnits(GetDirectMappingQueries())));
            Query itemCreditQuery = new ItemCreditMappingQuery("pish tegj glob glob is 42");
            MerchandiseConversions merchandiseConversion = MapQueries.MapQueriesToCredits((ItemCreditMappingQuery)itemCreditQuery,
                intergalacticUnits : GetIntergalacticUnits(GetDirectMappingQueries()),
                metalItems : GetMetals(
                    GetCreditItemMappingQueries(
                        GetIntergalacticUnits(GetDirectMappingQueries())), 
                GetIntergalacticUnits(GetDirectMappingQueries())));
            Assert.IsNotNull(merchandiseConversion);
            Assert.AreEqual(42, merchandiseConversion.ItemsValue, merchandiseConversion.ItemsValue);
        }

        [TestMethod()]
        public void MapQueriesToCreditsTest1()
        {
            List<Metal> lstMetals = new List<Metal>();
            lstMetals.AddRange(GetMetals(GetCreditItemMappingQueries(GetIntergalacticUnits(GetDirectMappingQueries())), GetIntergalacticUnits(GetDirectMappingQueries())));
            Query itemCreditQuery = new ItemCreditMappingQuery("how many Credits is glob prok Silver ?");
            MerchandiseConversions merchandiseConversion = MapQueries.MapQueriesToCredits((ItemCreditMappingQuery)itemCreditQuery,
                intergalacticUnits: GetIntergalacticUnits(GetDirectMappingQueries()),
                metalItems: GetMetals(
                    GetCreditItemMappingQueries(
                        GetIntergalacticUnits(GetDirectMappingQueries())),
                GetIntergalacticUnits(GetDirectMappingQueries())));
            Assert.IsNotNull(merchandiseConversion);
            Assert.AreEqual(68, merchandiseConversion.ItemsValue, merchandiseConversion.ItemsValue);
        }

        [TestMethod()]
        public void MapQueriesToCreditsTest2()
        {
            List<Metal> lstMetals = new List<Metal>();
            lstMetals.AddRange(GetMetals(GetCreditItemMappingQueries(GetIntergalacticUnits(GetDirectMappingQueries())), GetIntergalacticUnits(GetDirectMappingQueries())));
            Query itemCreditQuery = new ItemCreditMappingQuery("how many Credits is glob prok Gold ?");
            MerchandiseConversions merchandiseConversion = MapQueries.MapQueriesToCredits((ItemCreditMappingQuery)itemCreditQuery,
                intergalacticUnits: GetIntergalacticUnits(GetDirectMappingQueries()),
                metalItems: GetMetals(
                    GetCreditItemMappingQueries(
                        GetIntergalacticUnits(GetDirectMappingQueries())),
                GetIntergalacticUnits(GetDirectMappingQueries())));
            Assert.IsNotNull(merchandiseConversion);
            Assert.AreEqual(57800, merchandiseConversion.ItemsValue, merchandiseConversion.ItemsValue);
        }

        [TestMethod()]
        public void MapQueriesToCreditsTest3()
        {
            List<Metal> lstMetals = new List<Metal>();
            lstMetals.AddRange(GetMetals(GetCreditItemMappingQueries(GetIntergalacticUnits(GetDirectMappingQueries())), GetIntergalacticUnits(GetDirectMappingQueries())));
            Query itemCreditQuery = new ItemCreditMappingQuery("how many Credits is glob prok Iron ?");
            MerchandiseConversions merchandiseConversion = MapQueries.MapQueriesToCredits((ItemCreditMappingQuery)itemCreditQuery,
                intergalacticUnits: GetIntergalacticUnits(GetDirectMappingQueries()),
                metalItems: GetMetals(
                    GetCreditItemMappingQueries(
                        GetIntergalacticUnits(GetDirectMappingQueries())),
                GetIntergalacticUnits(GetDirectMappingQueries())));
            Assert.IsNotNull(merchandiseConversion);
            Assert.AreEqual(782, merchandiseConversion.ItemsValue, merchandiseConversion.ItemsValue);
        }

        [TestMethod()]
        public void MapQueriesToCreditsTest4()
        {
            List<Metal> lstMetals = new List<Metal>();
            lstMetals.AddRange(GetMetals(GetCreditItemMappingQueries(GetIntergalacticUnits(GetDirectMappingQueries())), GetIntergalacticUnits(GetDirectMappingQueries())));
            Query itemCreditQuery = new ItemCreditMappingQuery("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            MerchandiseConversions merchandiseConversion = MapQueries.MapQueriesToCredits((ItemCreditMappingQuery)itemCreditQuery,
                intergalacticUnits: GetIntergalacticUnits(GetDirectMappingQueries()),
                metalItems: GetMetals(
                    GetCreditItemMappingQueries(
                        GetIntergalacticUnits(GetDirectMappingQueries())),
                GetIntergalacticUnits(GetDirectMappingQueries())));
            Assert.IsNotNull(merchandiseConversion);
            Assert.AreEqual(0, merchandiseConversion.ItemsValue, merchandiseConversion.ItemsValue);
        }

        public List<DirectMappingQuery> GetDirectMappingQueries()
        {
            
            List<DirectMappingQuery> queries = new List<DirectMappingQuery> {
                new DirectMappingQuery("glob is I"),
                new DirectMappingQuery("prok is V"),
                new DirectMappingQuery("pish is X"),
                new DirectMappingQuery("tegj is L")
        };

            return queries;
        }

        public List<IntergalacticUnit> GetIntergalacticUnits(List<DirectMappingQuery> queries)
        {
            List<IntergalacticUnit> lstIntergalacticUnits = new List<IntergalacticUnit>();
            foreach (DirectMappingQuery query in queries)
            {
                var unit = MapQueries.MapUnit(query);
                if (unit != null)
                    lstIntergalacticUnits.Add(unit);
            }

            return lstIntergalacticUnits;
        }

        public List<CreditItemMappingQuery> GetCreditItemMappingQueries(List<IntergalacticUnit> lstIntergalacticUnits)
        {
            List<CreditItemMappingQuery> credititemMappingQueries = new List<CreditItemMappingQuery>
            {
                new CreditItemMappingQuery("glob glob Silver is 34 Credits"),
                new CreditItemMappingQuery("glob prok Gold is 57800 Credits"),
                new CreditItemMappingQuery("pish pish Iron is 3910 Credits")
            };

            return credititemMappingQueries;
        }

        public List<Metal> GetMetals(
            List<CreditItemMappingQuery> creditItemMappingQueries,
            List<IntergalacticUnit> lstIntergalacticUnits)
        {
            List<Metal> lstMetals = new List<Metal>();
            foreach(var query in creditItemMappingQueries)
            {
                lstMetals.Add(MapQueries.MapMetal(query, lstIntergalacticUnits));
            }

            return lstMetals;
        }
    }
}