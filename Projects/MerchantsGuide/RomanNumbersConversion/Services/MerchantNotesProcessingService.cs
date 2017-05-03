using RomanNumbersConversion.Domain;
using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Services
{
    public interface IMerchantNotesProcessingService
    {
        bool IdentifyIntergalacticUnits(List<DirectMappingQuery> directMappingQueries, MerchantNotebook merchantNotebook);
        bool IdentifyMetals(List<CreditItemMappingQuery> creditItemExampleQueries, MerchantNotebook merchantNotebook);
        bool IdentifyCreditsofQueries(List<ItemCreditMappingQuery> itemCreditMappingQueries, MerchantNotebook merchantNotebook);
        IntergalacticUnit MapUnit(DirectMappingQuery directMappingQuery);
        Metal MapMetal(CreditItemMappingQuery creditItemMappingQuery,
            List<IntergalacticUnit> intergalacticUnits);
        MerchandiseConversions MapQueriesToCredits(
            ItemCreditMappingQuery itemCreditMapping,
            List<IntergalacticUnit> intergalacticUnits,
            List<Metal> metalItems
            );


    }

    public class MerchantNotesProcessingService : IMerchantNotesProcessingService
    {
        private readonly IRomanToIntegerConversionService RomanConversionService;

        public MerchantNotesProcessingService(IRomanToIntegerConversionService RomanConversionService)
        {
            this.RomanConversionService = RomanConversionService;
        }

        public bool IdentifyIntergalacticUnits(List<DirectMappingQuery> directMappingQueries, MerchantNotebook merchantNotebook)
        {
            if (directMappingQueries.Count > 0 && merchantNotebook != null)
            {
                foreach(var directMappingQuery in directMappingQueries)
                {
                    var intergalacticUnit = MapUnit(directMappingQuery);
                    if(intergalacticUnit!=null)
                    {
                        merchantNotebook.IntergalacticUnits.Add(intergalacticUnit);
                    }
                }

                if(directMappingQueries.Count != merchantNotebook.IntergalacticUnits.Count)
                {
                    return false;
                }
                
                return true;
            }
            else
                return false;
        }

        public bool IdentifyMetals(List<CreditItemMappingQuery> creditItemExampleQueries, MerchantNotebook merchantNotebook)
        {
            if (creditItemExampleQueries.Count > 0 && merchantNotebook != null)
            {
                foreach (var creditItemExampleQuery in creditItemExampleQueries)
                {
                    var metal = MapMetal(creditItemExampleQuery, merchantNotebook.IntergalacticUnits);
                    if (metal != null)
                    {
                        merchantNotebook.Metals.Add(metal);
                    }
                }

                if (creditItemExampleQueries.Count != merchantNotebook.Metals.Count)
                {
                    return false;
                }

                return true;
            }
            else
                return false;
        }

        public bool IdentifyCreditsofQueries(List<ItemCreditMappingQuery> itemCreditMappingQueries, MerchantNotebook merchantNotebook)
        {
            if (itemCreditMappingQueries.Count > 0 && merchantNotebook != null)
            {
                foreach (var itemCreditMappingQuery in itemCreditMappingQueries)
                {
                    var queryResult = MapQueriesToCredits(itemCreditMappingQuery, merchantNotebook.IntergalacticUnits,merchantNotebook.Metals);
                    if (queryResult != null)
                    {
                        merchantNotebook.merchandiseConversions.Add(queryResult);
                    }
                }

                return true;
            }
            else
                return false;
        }

        public IntergalacticUnit MapUnit(DirectMappingQuery directMappingQuery)
        {
            string[] inputArray = directMappingQuery.Input.Split(' ');
            if (inputArray.Length == 3)
            {
                return new IntergalacticUnit
                {
                    UnitName = inputArray[0],
                    UnitRomanEquivalent = inputArray[2]
                };
            }

            return null;
        }

        public Metal MapMetal(CreditItemMappingQuery creditItemMappingQuery, 
            List<IntergalacticUnit> intergalacticUnits)
        {
            string[] queryItems = creditItemMappingQuery.NormalizedInput.Trim().Split(' ');
            decimal metalValue = -1;
            string metalName = string.Empty;
            IntergalacticUnit intergalacticUnit = null;
            StringBuilder romanNumeral = new StringBuilder();
            foreach (string s in queryItems)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if ((intergalacticUnit = intergalacticUnits.Where(x => x.UnitName.Equals(s)).FirstOrDefault()) != null)
                    {
                        romanNumeral.Append(intergalacticUnit.UnitRomanEquivalent);
                    }
                    if (Decimal.TryParse(s, out metalValue))
                        continue;

                    metalName = s;
                }
            }

            if (metalValue != -1 && !String.IsNullOrEmpty(metalName))
            {
                if (romanNumeral.Length > 0)
                {
                    int romanNumeralIntValue = RomanConversionService.ConvertToInt(romanNumeral.ToString());
                    if (romanNumeralIntValue != 0)
                    {
                        metalValue = metalValue / (decimal)romanNumeralIntValue;
                    }
                    else
                        return null;
                }
                return new Metal { MetalName = metalName, MetalValue = metalValue };
            }
            else
                return null;
        }

        public MerchandiseConversions MapQueriesToCredits(
            ItemCreditMappingQuery itemCreditMapping,
            List<IntergalacticUnit> intergalacticUnits,
            List<Metal> metalItems
            )
        {
            MerchandiseConversions merchandiseConversion = new MerchandiseConversions();
            merchandiseConversion.Output = "I have no idea what you are talking about";
            string[] queryItems = itemCreditMapping.NormalizedInput.Trim().Split(' ');
            IntergalacticUnit intergalacticUnit = null;
            Metal metalItem = null;
            foreach (string s in queryItems)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if ((intergalacticUnit = intergalacticUnits.Where(x => x.UnitName.Equals(s)).FirstOrDefault()) != null)
                    {
                        merchandiseConversion.IntergalacticUnits.Add(intergalacticUnit);
                        continue;
                    }

                    if ((metalItem = metalItems.Where(x => x.MetalName.Equals(s)).FirstOrDefault()) != null && merchandiseConversion.Metal == null)
                    {
                        merchandiseConversion.Metal = metalItem;
                        continue;
                    }

                }
            }

            if (merchandiseConversion.IntergalacticUnits.Count > 0 || merchandiseConversion.Metal != null)
            {
                merchandiseConversion.Output = "";
                if (merchandiseConversion.IntergalacticUnits.Count > 0)
                {
                    StringBuilder romanNumeral = new StringBuilder();
                    foreach (var units in merchandiseConversion.IntergalacticUnits)
                    {
                        romanNumeral.Append(units.UnitRomanEquivalent);
                        merchandiseConversion.Output += units.UnitName + " ";
                    }

                    merchandiseConversion.ItemsValue = RomanConversionService.ConvertToInt(romanNumeral.ToString());
                }

                if (merchandiseConversion.Metal != null)
                {
                    merchandiseConversion.ItemsValue = merchandiseConversion.ItemsValue == 0 ?
                        1 * merchandiseConversion.Metal.MetalValue :
                        merchandiseConversion.ItemsValue * merchandiseConversion.Metal.MetalValue;

                    merchandiseConversion.Output += merchandiseConversion.Metal.MetalName + " is " + merchandiseConversion.ItemsValue.ToString("0") + " Credits";
                }
                else
                {
                    merchandiseConversion.Output += "is " + merchandiseConversion.ItemsValue.ToString("0");
                }

            }

            return merchandiseConversion;
        }
    }
}
