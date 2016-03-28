#define symbol
using System;
using CSharpConcepts.Interfaces;
using System.Diagnostics;

namespace CSharpConcepts.DebugingConcepts
{
    internal class DirectivesUsageExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Using Preprocess compiler directives");
        }

        public void MainMethod()
        {
            UsingIfDirective();
            UsingCustomDirective();
            UsingErrorAndWarningDirective();
            UsingPragmaDirective();
            Console.WriteLine("Methods can be made to run only in debug mode using ConditionalDirective");
            UsingAttributeForMethodSuppress();
            UsingDebuggerDisplayAttribute();

        }

        private void UsingIfDirective()
        {
#if DEBUG
            Console.WriteLine("Running in debug mode");
#else
            Console.WriteLine("Running in Release mode");
#endif
        }

        private void UsingCustomDirective()
        {
            Console.WriteLine("Using Custom Directive example");
#if symbol
            Console.WriteLine("Custom symbol is defined");
#endif
        }

        private void UsingErrorAndWarningDirective()
        {
            Console.WriteLine("Using Warning and Error Directive");
#warning This code is obsolete

#if DEBUG
//#error Debug Build is not allowed
#endif
        }

        private void UsingPragmaDirective()
        {
            Console.WriteLine("Suppressing the warning using pragma directive");
#pragma warning disable
            while(false)
            {
                Console.WriteLine("Unreachable code");
            }
        }

        [Conditional("DEBUG")]
        private void UsingAttributeForMethodSuppress()
        {
            Console.WriteLine("Method is called only when run in debug mode");
        }

        private void UsingDebuggerDisplayAttribute()
        {
            Console.WriteLine("Debugger Display Example");
            Console.Write("Debugger calles ToString for each object that is called for value. The defaul implementation shows name of the type.");
            Console.WriteLine("DisplayDebugger is used by VS debugger to display an object.");
            Person person = new Person();
            person.FirstName = "Mayank";
            person.LastName = "Aggarwal";
            PersonWithoutDebugger person1 = new PersonWithoutDebugger();
            person1.FirstName = "Mayank";
            person1.LastName = "Aggarwal";
            Console.WriteLine(person);
        }

        [DebuggerDisplay("Name = {FirstName} {LastName}")]
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        public class PersonWithoutDebugger
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}