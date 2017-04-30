using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.UserQueriesEntities
{
    public class CreditItemMappingQuery:Query
    {
        public CreditItemMappingQuery(string input)
        {
            this.Input = input;
            WordsToRemove.Add(" is");
            WordsToRemove.Add(" Credits");
            foreach (string s in this.WordsToRemove)
            {
                input = input.Replace(s, "");
            }

            this.NormalizedInput = input;
        }
    }
}
