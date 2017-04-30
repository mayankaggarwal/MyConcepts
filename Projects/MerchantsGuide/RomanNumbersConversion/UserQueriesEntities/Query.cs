using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.UserQueriesEntities
{
    public abstract class Query
    {
        public string Input { get;internal set; }
        public string NormalizedInput { get; internal set; }
        public readonly List<string> WordsToRemove = new List<string>();

        public static Query IdentifyQueryType(string input)
        {
            if (input.Split(' ').Length == 3)
                return new DirectMappingQuery(input);
            else if (input.ToUpper().Contains("CREDITS") && !input.ToUpper().Contains("HOW"))
                return new CreditItemMappingQuery(input);
            else if (input.ToUpper().Contains("HOW"))
                return new ItemCreditMappingQuery(input);

            return null;
        }
    }
}
