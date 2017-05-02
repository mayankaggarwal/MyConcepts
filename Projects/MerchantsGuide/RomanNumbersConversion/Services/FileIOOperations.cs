using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumbersConversion.Services
{
    public interface IFileIOOperations
    {
        List<string> ReadGuidesNotes(string filePath);

        bool WriteGuideOutput(string filePath,List<string> guideOutput);
    }
    public class FileIOOperations : IFileIOOperations
    {
        public List<string> ReadGuidesNotes(string filePath)
        {
            List<string> inputNotes = new List<string>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string input = string.Empty;
                    while ((input = reader.ReadLine()) != null)
                    {
                        inputNotes.Add(input);
                    }
                }
            }

            return inputNotes;
        }

        public bool WriteGuideOutput(string filePath, List<string> guideOutput)
        {
            if (Directory.Exists(Path.GetDirectoryName(filePath)))
            {
                using (StreamWriter writer = new StreamWriter(filePath,false))
                {
                    foreach(string outputLine in guideOutput)
                    {
                        writer.WriteLine(outputLine);
                    }
                }

                return true;
            }
            else
                return false;
        }
    }

}
