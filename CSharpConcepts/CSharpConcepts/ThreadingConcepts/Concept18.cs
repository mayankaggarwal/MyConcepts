using CSharpConcepts.Interfaces;
using System;
using System.Collections.Concurrent;

namespace CSharpConcepts.ThreadingConcepts
{
    internal class Concept18 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Concurrent Dictionary Example");
        }

        public void MainMethod()
        {
            Console.WriteLine("Concurrent Dictionary Run implementation");
            ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();
            if(dictionary.TryAdd("k1",10))
            {
                Console.WriteLine("Added Key k1");
            } 

            if(dictionary.TryUpdate("k1",19,10))
            {
                Console.WriteLine("Updated Key k1");
            }

            if (dictionary.TryUpdate("k1", 19, 10))
            {
                Console.WriteLine("Updated Key k1");
            }
            else
                Console.WriteLine("Failed to Update");

            dictionary["k1"] = 16;

            int r1 = dictionary.AddOrUpdate("k1", 2, (s, i) => i * 2);
            Console.WriteLine(r1);
            int r3 = dictionary.AddOrUpdate("k3", 2, (s, i) => i * 2);
            Console.WriteLine(r3);
            int r2 = dictionary.GetOrAdd("k2", 4);
            Console.WriteLine(r2);
        }
    }
}