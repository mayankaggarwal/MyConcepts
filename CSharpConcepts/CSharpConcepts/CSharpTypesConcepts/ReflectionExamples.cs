using System;
using CSharpConcepts.Interfaces;

namespace CSharpConcepts.CSharpTypesConcepts
{
    internal class ReflectionExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Reflection Examples");
            Console.WriteLine("A .Net application contains code, data and also metadata.");
            Console.Write("Metadata Information like attributes. Other metadata contain information about");
            Console.WriteLine("types, code, assembly and all other elements stored in application");
            Console.WriteLine("Reflection is the process of retriveing this metadata information at runtime");
        }

        public void MainMethod()
        {
            Console.WriteLine("Not implemented");
        }
    }
}