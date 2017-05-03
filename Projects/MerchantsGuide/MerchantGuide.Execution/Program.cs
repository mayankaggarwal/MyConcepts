using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantGuide.Execution
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = string.Empty;

            if(args.Length>0)
            {
                filePath = args[0];
            }
            else
            {
                filePath = "TempFile/TestInput.txt";
            }
            if (File.Exists(filePath))
            {
                RomanNumbersConversion.IMerchantNotebookProcessor merchantNotebookProcessor = new RomanNumbersConversion.MerchantNotebookProcessor(
                    new RomanNumbersConversion.Services.FileIOOperations(),
                    new RomanNumbersConversion.Services.MerchantsNotesIdentifierService(),
                    new RomanNumbersConversion.Services.RomanToIntegerConversionService(),
                    new RomanNumbersConversion.Services.MerchantNotesProcessingService(new RomanNumbersConversion.Services.RomanToIntegerConversionService())
                   );

                merchantNotebookProcessor.PrepareGuide(filePath);
                merchantNotebookProcessor.ProcessOutput(filePath.Substring(0,filePath.LastIndexOf('.')) + "_Ouput" + Path.GetExtension(filePath));
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            Console.WriteLine("Press eny key to exit");
            Console.ReadLine();
        }
    }
}
