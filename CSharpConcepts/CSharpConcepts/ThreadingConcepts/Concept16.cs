using System;
using CSharpConcepts.Interfaces;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Removing an item from the collection can be blocked until data becomes available.
    /// If no specific instruction is given , then it uses ConcurrentQueue by default
    /// use CompleteAdding method to signal Blocking collection that no other item can be added.
    /// </summary>
    internal class Concept16 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Blocking collection example");
            Console.WriteLine("Removing an item from the collection can be blocked until data becomes available.");
            Console.WriteLine("If no specific instruction is given , then it uses ConcurrentQueue by default");
            Console.WriteLine("use CompleteAdding method to signal Blocking collection that no other item can be added.");
        }

        public void MainMethod()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();
            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("Current Thread Id1 :" + System.Threading.Thread.CurrentThread.ManagedThreadId + " " + col.Take());
                }
            });

            Task read2 = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("Current Thread Id2 :" + System.Threading.Thread.CurrentThread.ManagedThreadId + " " + col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(s))
                        break;
                    col.Add(s);
                }
            });

            //Task write = Task.Run(() =>
            //{
            //    foreach (string v in col.GetConsumingEnumerable())
            //        col.Add(v);
            //});

            write.Wait();
        }
    }
}