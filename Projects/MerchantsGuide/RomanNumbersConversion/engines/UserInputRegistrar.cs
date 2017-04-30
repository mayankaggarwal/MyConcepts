using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.engines
{
    public static class UserInputRegistrar
    {
        public static Query DistributeInput(string inputLines)
        {
            return Query.IdentifyQueryType(inputLines);
        }
    }
}
