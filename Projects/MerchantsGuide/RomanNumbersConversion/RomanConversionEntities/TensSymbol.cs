using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.RomanConversion
{
    internal class TensSymbol:SymbolRepresentation
    {
        public TensSymbol()
        {
            symbolValues.Add("XC", 90);
            symbolValues.Add("L", 50);
            symbolValues.Add("XL", 40);
            symbolValues.Add("X", 10);
        }
    }
}
