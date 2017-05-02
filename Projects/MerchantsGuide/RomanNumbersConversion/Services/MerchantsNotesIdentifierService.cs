using RomanNumbersConversion.Domain;
using RomanNumbersConversion.UserQueriesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Services
{
    public interface IMerchantsNotesIdentifierService
    {
        MerchantNotesIdentificationResult IdentifyMerchantNotes(List<string> initialMerchantNotes);

        List<DirectMappingQuery> GetIntergalacticUnitsQueries(List<MerchantNote> identitifedQueries);

        List<CreditItemMappingQuery> GetIntergalacticTransactionQueries(List<MerchantNote> identitifedQueries);

        List<ItemCreditMappingQuery> GetPostedQueries(List<MerchantNote> identitifedQueries);

    }
    public class MerchantsNotesIdentifierService : IMerchantsNotesIdentifierService
    {
        public MerchantNotesIdentificationResult IdentifyMerchantNotes(List<string> initialMerchantNotes)
        {
            MerchantNotesIdentificationResult merchantNotesIdentificationResult = new MerchantNotesIdentificationResult();

            if (initialMerchantNotes.Count > 0)
            {
                foreach (string initialNote in initialMerchantNotes)
                {
                    var identifiedNote = DistributeInput(initialNote);
                    if (identifiedNote != null)
                    {
                        merchantNotesIdentificationResult.IdentifiedMerchantNotes.Add(identifiedNote);
                    }
                    else
                    {
                        merchantNotesIdentificationResult.NonIdentifiedMerchantNotes.Add(initialNote);
                    }
                }
            }

            return merchantNotesIdentificationResult;
        }
        public MerchantNote DistributeInput(string inputLines)
        {
            return MerchantNote.IdentifyQueryType(inputLines);
        }

        public List<DirectMappingQuery> GetIntergalacticUnitsQueries(List<MerchantNote> identitifedQueries)
        {
            List<DirectMappingQuery> directMappingQueries = new List<DirectMappingQuery>();
            foreach (var merchantNote in identitifedQueries)
            {
                if (merchantNote is DirectMappingQuery)
                {
                    directMappingQueries.Add(merchantNote as DirectMappingQuery);
                }
            }

            return directMappingQueries;
        }

        public List<CreditItemMappingQuery> GetIntergalacticTransactionQueries(List<MerchantNote> identitifedQueries)
        {
            List<CreditItemMappingQuery> creditItemMappingQuery = new List<CreditItemMappingQuery>();
            foreach (var merchantNote in identitifedQueries)
            {
                if (merchantNote is CreditItemMappingQuery)
                {
                    creditItemMappingQuery.Add(merchantNote as CreditItemMappingQuery);
                }
            }

            return creditItemMappingQuery;
        }

        public List<ItemCreditMappingQuery> GetPostedQueries(List<MerchantNote> identitifedQueries)
        {
            List<ItemCreditMappingQuery> itemCreditMappingQuery = new List<ItemCreditMappingQuery>();
            foreach (var merchantNote in identitifedQueries)
            {
                if (merchantNote is ItemCreditMappingQuery)
                {
                    itemCreditMappingQuery.Add(merchantNote as ItemCreditMappingQuery);
                }
            }

            return itemCreditMappingQuery;
        }
    }
}
