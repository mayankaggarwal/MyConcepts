using System;
using CSharpConcepts.Interfaces;
using System.Collections.Generic;

namespace CSharpConcepts.ImplementingProgramFlow
{
    internal class ForeachImpConcept : IMainMethod
    {
        List<Person> people = new List<Person>
            {
                new Person() {FirstName = "Mayank",LastName = "Aggarwal" },
                new Person() {FirstName = "MA",LastName="Agg" }
            };

        public void SummaryMethod()
        {
            Console.WriteLine("");
        }

        public void MainMethod()
        {
            Console.WriteLine("Foreach implementation by compiler");
            IterateUsingForeach();
        }


        public void IterateUsingForeach()
        {
            Console.WriteLine("Iterating using foreach");


            foreach(Person p in people)
            {
                p.LastName = "Changed"; //This is allowed
                //p = new Person(); // This gives compile time error;
                Console.WriteLine("FirstName :" + p.FirstName + " LastName :" + p.LastName);
            }
        }

        public void IterateUsingForeachImplementation()
        {
            Console.WriteLine("Compiler Implementation of Foreach");
            List<Person>.Enumerator e = people.GetEnumerator();
            try
            {
                Person v;
                while(e.MoveNext())
                {
                    v = e.Current;
                }
            }
            finally
            {
                System.IDisposable d = e as System.IDisposable;
                if (d != null) d.Dispose();
            }
            Console.WriteLine("If we change the value of e.Current to something else the iterator pattern can't detremine what to do when e.MoveNext is called");
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}