using RomanNumbersConversion.Domain;
using RomanNumbersConversion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion
{
    public class MerchantNotebookProcessor
    {
        private readonly IFileIOOperations fileIOOperations;
        private readonly IMerchantsNotesIdentifierService merchantNotesIdentificationService;
        private readonly IRomanToIntegerConversionService romanToIntegerConversionService;
        private readonly IMerchantNotesProcessingService merchantNotesProcessingService;
        private readonly MerchantNotebook merchantNoteBook;
        private bool NotebookPrepared;

        public MerchantNotebookProcessor()
        {
            fileIOOperations = new FileIOOperations();
            merchantNotesIdentificationService = new MerchantsNotesIdentifierService();
            romanToIntegerConversionService = new RomanToIntegerConversionService();
            merchantNotesProcessingService = new MerchantNotesProcessingService(romanToIntegerConversionService);
            merchantNoteBook = MerchantNotebook.Instance;
            NotebookPrepared = false;
        }

        public bool PrepareGuide(string filePath)
        {
            List<string> initialMerchantsNotes = new List<string>();
            initialMerchantsNotes.AddRange(fileIOOperations.ReadGuidesNotes(filePath));
            if (initialMerchantsNotes.Count() == 0)
                return false;

            MerchantNotesIdentificationResult merchantNotesIdentificationResult = new MerchantNotesIdentificationResult();
            merchantNotesIdentificationResult = merchantNotesIdentificationService.IdentifyMerchantNotes(initialMerchantsNotes);

            if (merchantNotesIdentificationResult.IdentifiedMerchantNotes.Count == 0 ||
                merchantNotesIdentificationResult.NonIdentifiedMerchantNotes.Count > 0)
                return false;

            
            bool intergalacticUnitsIdentification = merchantNotesProcessingService.IdentifyIntergalacticUnits(
                merchantNotesIdentificationService.GetIntergalacticUnitsQueries(
                    merchantNotesIdentificationResult.IdentifiedMerchantNotes), 
                merchantNoteBook);
            if (!intergalacticUnitsIdentification)
                return false;


            bool metalsIdentification = merchantNotesProcessingService.IdentifyMetals(
                merchantNotesIdentificationService.GetIntergalacticTransactionQueries(
                    merchantNotesIdentificationResult.IdentifiedMerchantNotes),
                merchantNoteBook);
            if (!metalsIdentification)
                return false;

            bool ouputIdentification = merchantNotesProcessingService.IdentifyCreditsofQueries(
                merchantNotesIdentificationService.GetPostedQueries(
                    merchantNotesIdentificationResult.IdentifiedMerchantNotes),
                merchantNoteBook);
            if (!ouputIdentification)
                return false;

            this.NotebookPrepared = true;
            return true;
        }

        public bool ProcessOutput(string fileName)
        {
            if (NotebookPrepared)
            {
                List<string> output = new List<string>();
                foreach(var merchandiseConversion in merchantNoteBook.merchandiseConversions)
                {
                    output.Add(merchandiseConversion.Output);
                }

               
            }
            else
                return false ;
        }
    }
}
