using RomanNumbersConversion.Domain;
using RomanNumbersConversion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion
{
    public interface IMerchantNotebookProcessor
    {
        bool PrepareGuide(string filePath);
        bool ProcessOutput(string fileName);
    }

    public class MerchantNotebookProcessor:IMerchantNotebookProcessor
    {
        private readonly IFileIOOperations fileIOOperations;
        private readonly IMerchantsNotesIdentifierService merchantNotesIdentificationService;
        private readonly IRomanToIntegerConversionService romanToIntegerConversionService;
        private readonly IMerchantNotesProcessingService merchantNotesProcessingService;
        private readonly MerchantNotebook merchantNoteBook;
        private bool NotebookPrepared;

        public MerchantNotebookProcessor(IFileIOOperations fileIOOperations,
            IMerchantsNotesIdentifierService merchantNotesIdentificationService,
            IRomanToIntegerConversionService romanToIntegerConversionService,
            IMerchantNotesProcessingService merchantNotesProcessingService)
        {
            this.fileIOOperations = fileIOOperations;
            this.merchantNotesIdentificationService = merchantNotesIdentificationService;
            this.romanToIntegerConversionService = romanToIntegerConversionService;
            this.merchantNotesProcessingService = merchantNotesProcessingService;
            this.merchantNoteBook = MerchantNotebook.Instance;
            this.NotebookPrepared = false;
        }

        public bool PrepareGuide(string filePath)
        {
            merchantNoteBook.Reset();

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

                bool writeResult = fileIOOperations.WriteGuideOutput(fileName,output);
                return writeResult;
               
            }
            else
                return false ;
        }
    }
}
