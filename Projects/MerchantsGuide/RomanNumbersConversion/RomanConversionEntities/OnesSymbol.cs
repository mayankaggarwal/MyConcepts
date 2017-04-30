using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.RomanConversion
{
    public class OnesSymbol:SymbolRepresentation
    {
        public OnesSymbol()
        {
            symbolValues.Add("IX", 9);
            symbolValues.Add("V", 5);
            symbolValues.Add("IV", 4);
            symbolValues.Add("I", 1);
        }
    }
}
