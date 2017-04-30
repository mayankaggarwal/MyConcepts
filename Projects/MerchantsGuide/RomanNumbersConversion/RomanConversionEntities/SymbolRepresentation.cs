using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.RomanConversion
{
    public abstract class SymbolRepresentation
    {
        public readonly Dictionary<string, int> symbolValues = new Dictionary<string, int>();

        public int EvaluateInputExpression(ref string input)
        {
            int result = 0;
            foreach(var symbolkeyValuePair in symbolValues)
            {
                if(input.StartsWith(symbolkeyValuePair.Key))
                {
                    result += symbolkeyValuePair.Value;
                    input = input.Substring(symbolkeyValuePair.Key.Length);
                }
            }

            string key = symbolValues.Keys.ElementAt(symbolValues.Count() - 1);
            while(input.StartsWith(key))
            {
                result += symbolValues[key];
                input = input.Substring(key.Length);
            }

            return result;
        }
    }
}
