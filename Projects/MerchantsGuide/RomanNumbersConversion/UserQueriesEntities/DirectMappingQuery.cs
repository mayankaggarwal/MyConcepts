using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.UserQueriesEntities
{
    public class DirectMappingQuery:Query
    {
        public DirectMappingQuery(string input)
        {
            this.Input = input;
            WordsToRemove.Add("is");
            foreach(string s in this.WordsToRemove)
            {
                input = input.Replace(s, "");
            }

            this.NormalizedInput = input;
        }
    }
}
