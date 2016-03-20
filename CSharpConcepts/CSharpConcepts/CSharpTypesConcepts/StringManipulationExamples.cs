using System;
using CSharpConcepts.Interfaces;
using System.IO;
using System.Xml;
using System.Globalization;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class StringManipulationExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("String Manipulation Examples");
        }

        public void MainMethod()
        {
            UsingStringReaderAndStringWriter();
        }

        private void UsingStringReaderAndStringWriter()
        {
            Console.WriteLine("String Reader and String Writer example");
            Console.WriteLine("Some APIs expects TestWriter and TextReader but they can't work with string or StringBuilder. StringWriter and StringReader adapts to the interface of StringBuilder.");
            
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stringWriter))
            {
                writer.WriteStartElement("book");
                writer.WriteElementString("price", "19.95");
                writer.WriteEndElement();
                writer.Flush();
            }

            string xml = stringWriter.ToString();
            Console.WriteLine("String created using StringWriter and XMLWriter is :");
            Console.WriteLine(xml);

            StringReader stringReader = new StringReader(xml);
            using (XmlReader reader = XmlReader.Create(stringReader))
            {
                reader.ReadToFollowing("price");
                decimal price = decimal.Parse(reader.ReadInnerXml(),new CultureInfo("en-US"));
                Console.WriteLine("Price read using String Reader and XMLReader is :" + price);
            }

            stringWriter.Close();
            stringReader.Close();
        }
    }
}