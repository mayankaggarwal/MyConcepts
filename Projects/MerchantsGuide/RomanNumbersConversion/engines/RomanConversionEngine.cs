using RomanNumbersConversion.RomanConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.engines
{
    public static class RomanConversionEngine
    {
        public static int ConvertToInt(string input)
        {
            int result = 0;
            SymbolRepresentation symbolRepresentation;

            symbolRepresentation = new ThousandSymbol();
            result += symbolRepresentation.EvaluateInputExpression( ref input);
            symbolRepresentation = new HundredSymbol();
            result += symbolRepresentation.EvaluateInputExpression(ref input);
            symbolRepresentation = new TensSymbol();
            result += symbolRepresentation.EvaluateInputExpression(ref input);
            symbolRepresentation = new OnesSymbol();
            result += symbolRepresentation.EvaluateInputExpression(ref input);

            return result;

        }
    }
}
