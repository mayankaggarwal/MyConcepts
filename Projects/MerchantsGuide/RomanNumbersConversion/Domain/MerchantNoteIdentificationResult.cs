using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Domain
{
    public class MerchantNotesIdentificationResult
    {
        public List<MerchantNote> IdentifiedMerchantNotes = new List<MerchantNote>();
        public List<string> NonIdentifiedMerchantNotes = new List<string>();
    }
}
