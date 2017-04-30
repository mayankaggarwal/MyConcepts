using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.UserQueriesEntities
{
    public class ItemCreditMappingQuery:Query
    {
        public ItemCreditMappingQuery(string input)
        {
            this.Input = input;
            WordsToRemove.Add(" is");
            WordsToRemove.Add(" Credits");
            WordsToRemove.Add("how ");
            WordsToRemove.Add(" much");
            WordsToRemove.Add(" many");
            WordsToRemove.Add(" ?");
            foreach (string s in this.WordsToRemove)
            {
                input = input.Replace(s, "");
            }

            this.NormalizedInput = input;
        }
    }
}
