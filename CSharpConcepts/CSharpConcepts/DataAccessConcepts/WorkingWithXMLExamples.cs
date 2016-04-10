using System;
using CSharpConcepts.Interfaces;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class WorkingWithXMLExamples : IMainMethod
    {
        string xmlDoc = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
                        <people>
                            <person firstname=""john"" lastname=""doe"">
                                <contactdetails>
                                    <emailaddress>john@unkown.com</emailaddress>
                                </contactdetails>
                            </person>
                            <person firstname=""jane"" lastname=""doe"">
                                <contactdetails>
                                    <emailaddress>jane@unkown.com</emailaddress>
                                    <phonenumber>0070070071</phonenumber>
                                </contactdetails>
                            </person>
                        </people>";

        public void SummaryMethod()
        {
            Console.WriteLine("Working with XML Examples");
        }

        public void MainMethod()
        {
            UsingXmlReaderExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingXmlWriterExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingXmlDocumentExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingXPathNavigatorExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingXDocumentWithLINQ();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }


        private void UsingXmlReaderExample()
        {
            Console.WriteLine("Reading XML string using XmlReader abstract class");
            using (StringReader reader = new StringReader(xmlDoc))
            {
                using (XmlReader xmlReader = XmlReader.Create(reader, new XmlReaderSettings() { IgnoreWhitespace = true }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");
                    string firstname = xmlReader.GetAttribute("firstname");
                    string lastname = xmlReader.GetAttribute("lastname");

                    Console.WriteLine("Person: {0} {1}", firstname, lastname);

                    xmlReader.ReadStartElement("person");
                    Console.WriteLine("ContactDetails");
                    xmlReader.ReadStartElement("contactdetails");
                    string emailAddress = xmlReader.ReadElementContentAsString();

                    Console.WriteLine("Email Address: {0}", emailAddress);

                }
            }
        }

        private void UsingXmlWriterExample()
        {
            Console.WriteLine("Writing XML string using XmlWriter abstract class");
            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings() { Indent = true }))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("People");
                    xmlWriter.WriteStartElement("Person");
                    xmlWriter.WriteAttributeString("firstname", "mayank");
                    xmlWriter.WriteAttributeString("lastname", "aggarwal");
                    xmlWriter.WriteStartElement("contactdetails");
                    xmlWriter.WriteElementString("EmailAddress", "mayank@unknown.com");
                    //xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                    xmlWriter.Flush();
                }

                Console.WriteLine(stringWriter.ToString());
            }
        }

        private void UsingXmlDocumentExample()
        {
            Console.WriteLine("Reading XML string using XmlDocument abstract class");
            XmlDocument doc = new XmlDocument();

            doc.LoadXml(xmlDoc);

            XmlNodeList nodeList = doc.GetElementsByTagName("person");
            foreach(XmlNode node in nodeList)
            {
                string firstName = node.Attributes["firstname"].ToString();
                string lastname = node.Attributes["lastname"].ToString();
                Console.WriteLine("Name: {0} {1}", firstName, lastname);
            }

            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");

            XmlAttribute fName = doc.CreateAttribute("firstname");
            fName.Value = "Mayank";

            XmlAttribute lName = doc.CreateAttribute("lastname");
            lName.Value = "Aggarwal";

            newNode.Attributes.Append(fName);
            newNode.Attributes.Append(lName);

            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modifed XML.........");
            doc.Save(Console.Out);
         
        }

        private void UsingXPathNavigatorExample()
        {
            Console.WriteLine("Parsing XML string using XPathNavigator abstract class");
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDoc);

            XPathNavigator nav = doc.CreateNavigator();
            string query = "//people/person[@fistname='jane']";
            XPathNodeIterator iterator = nav.Select(query);
            Console.WriteLine(iterator.Count);

            while(iterator.MoveNext())
            {
                string firstname = iterator.Current.GetAttribute("firstname", "");
                string lastname = iterator.Current.GetAttribute("lastname", "");
                Console.WriteLine("Name : {0} {1}", firstname, lastname);
            }
        }

        private void UsingXDocumentWithLINQ()
        {
            Console.WriteLine("Manipulating XML using XDocument");

            XDocument doc = XDocument.Parse(xmlDoc);
            Console.WriteLine("\n-------------Quering XML by using LINQ to XML");
            {
                IEnumerable<string> personNames = from p in doc.Descendants("person")
                                                  select (string)p.Attribute("firstname") + " " + (string)p.Attribute("lastname");

                foreach (var personName in personNames)
                    Console.WriteLine(personName);

            }

            Console.WriteLine("\n-------------Using OrderBy and Where in quering using LINQ to XML");
            {
                IEnumerable<string> personNames1 = from p in doc.Descendants("person")
                                                   where p.Descendants("phonenumber").Any()
                                                   let name = (string)p.Attribute("firstname") + " " + (string)p.Attribute("lastname")
                                                   orderby name
                                                   select name;
                foreach (var personName in personNames1)
                    Console.WriteLine(personName);
            }

            Console.WriteLine("\n-----------Updating XML in procedural way:");
            {
                XElement root = XElement.Parse(xmlDoc);
                foreach(XElement p in root.Descendants("person"))
                {
                    string name = (string)p.Attribute("firstname") + " " + (string)p.Attribute("lastname");
                    p.Add(new XAttribute("IsMale", name.Contains("john")));
                    XElement contactDetails = p.Element("contactdetails");
                    if(!contactDetails.Descendants("phonenumber").Any())
                    {
                        contactDetails.Add(new XElement("phonenumber", "9972444568"));
                    }

                }

                root.Save(Console.Out);
            }

            Console.WriteLine("\n-------------Transformaing XML using functional creation");
            {
                XElement root = XElement.Parse(xmlDoc);
                XElement newElement = new XElement("people",
                    from p in root.Descendants("person")
                    let name = (string)p.Attribute("firstname") + (string)p.Attribute("lastname")
                    let contactdetails = p.Element("contactdetails")
                    select new XElement("Person", new XAttribute("IsMale", name.Contains("john")),
                        p.Attributes(),
                        new XElement("contactdetails",
                            contactdetails.Element("emailaddress"),
                            contactdetails.Element("phonenumber") ?? new XElement("phonenumber", "9972444568")
                    )));

                newElement.Save(Console.Out);
              
            }

        }

    }
}