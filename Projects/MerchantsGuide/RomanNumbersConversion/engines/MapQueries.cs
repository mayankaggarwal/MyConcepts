﻿using RomanNumbersConversion.Domain;
using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.engines
{
    public static class MapQueries
    {
        public static IntergalacticUnit MapUnit(DirectMappingQuery directMappingQuery)
        {
            string[] inputArray = directMappingQuery.Input.Split(' ');
            if(inputArray.Length==3)
            {
                return new IntergalacticUnit
                {
                    UnitName = inputArray[0],
                    UnitRomanEquivalent = inputArray[2]
                };
            }

            return null;
        }

        public static Metal MapMetal(
            CreditItemMappingQuery creditItemMappingQuery
            ,List<IntergalacticUnit> intergalacticUnits)
        {
            string[] queryItems = creditItemMappingQuery.NormalizedInput.Trim().Split(' ');
            long metalValue = -1;
            string metalName = string.Empty;
            IntergalacticUnit intergalacticUnit = null;
            StringBuilder romanNumeral = new StringBuilder();
            foreach(string s in queryItems)
            {
                if (!string.IsNullOrWhiteSpace(s))
                {
                    if ((intergalacticUnit = intergalacticUnits.Where(x => x.UnitName.Equals(s)).FirstOrDefault()) != null)
                    {
                        romanNumeral.Append(intergalacticUnit.UnitRomanEquivalent);
                    }
                    if (Int64.TryParse(s, out metalValue))
                        continue;

                    metalName = s;
                }
            }

            if (metalValue != -1 && !String.IsNullOrEmpty(metalName))
            {
                if(romanNumeral.Length>0)
                {
                    int romanNumeralIntValue = RomanConversionEngine.ConvertToInt(romanNumeral.ToString());
                    if (romanNumeralIntValue != 0)
                    {
                        metalValue = metalValue / (long)romanNumeralIntValue;
                    }
                    else
                        return null;
                }
                return new Metal { MetalName = metalName, MetalValue = metalValue };
            }
            else
                return null;
        }

        public static MerchandiseConversions MapQueriesToCredits(
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
                if(merchandiseConversion.IntergalacticUnits.Count>0)
                {
                    StringBuilder romanNumeral = new StringBuilder();
                    foreach(var units in merchandiseConversion.IntergalacticUnits)
                    {
                        romanNumeral.Append(units.UnitRomanEquivalent);
                        merchandiseConversion.Output += units.UnitName + " ";
                    }

                    merchandiseConversion.ItemsValue = RomanConversionEngine.ConvertToInt(romanNumeral.ToString());
                }

                if(merchandiseConversion.Metal != null)
                {
                    merchandiseConversion.ItemsValue = merchandiseConversion.ItemsValue == 0 ?
                        1 * merchandiseConversion.Metal.MetalValue :
                        merchandiseConversion.ItemsValue * merchandiseConversion.Metal.MetalValue;

                    merchandiseConversion.Output += merchandiseConversion.Output + "is " + merchandiseConversion.ItemsValue + " Credits";
                }
                else
                {
                    merchandiseConversion.Output += merchandiseConversion.Output + "is " +merchandiseConversion.ItemsValue;
                }

            }

            return merchandiseConversion;
        }
    }
}
