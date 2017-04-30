using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.RomanConversion
{
    public class HundredSymbol:SymbolRepresentation
    {
        public HundredSymbol()
        {
            symbolValues.Add("CM", 900);
            symbolValues.Add("D", 500);
            symbolValues.Add("CD", 400);
            symbolValues.Add("C", 100);
        }
    }
}
