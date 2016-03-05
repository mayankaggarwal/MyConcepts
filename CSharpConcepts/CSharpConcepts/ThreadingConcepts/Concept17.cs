using CSharpConcepts.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// It is bag of items. It enables duplicates and has no particular order
    /// The iteration over Concurrent Bag is thread safe as it makes a snapshot of collection when we start iterating over it.
    /// </summary>
    internal class Concept17 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Concurrent Bag Example");
            Console.WriteLine("It is bag of items. It enables duplicates and has no particular order");
            Console.WriteLine("The iteration over Concurrent Bag is thread safe as it makes a snapshot of collection when we start iterating over it.");
        }

        public void MainMethod()
        {
            Example1();
            Example2();
        }

        private void Example1()
        {
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();

            concurrentBag.Add(21);
            concurrentBag.Add(43);
            concurrentBag.Add(32);

            Console.WriteLine("Initial Concurrent Bag count :" + concurrentBag.Count);
            int result;
            if (concurrentBag.TryTake(out result))
                Console.WriteLine("Concurrent bag count after Take :" + concurrentBag.Count);

            if (concurrentBag.TryPeek(out result))
                Console.WriteLine("Concurrent bag count after Peek :" + concurrentBag.Count);

        }

        private void Example2()
        {
            Console.WriteLine("With List multithreading throws an error");
            //List<int> list = new List<int>();
            //Task.Run(() =>
            //{
            //    list.Add(21);
            //    Thread.Sleep(250);
            //    list.Add(43);
            //    Thread.Sleep(500);
            //    list.Remove(21);
            //    Thread.Sleep(500);
            //    list.Add(63);
            //});

            //Task.Run(() =>
            //{
            //    //foreach (int i in list)
            //    //{
            //    //    Thread.Sleep(500);
            //    //    Console.WriteLine(i);
            //    //}
            //    for(int i=0;i<list.Count;i++)
            //    {
            //        Thread.Sleep(500);
            //        Console.WriteLine(list[i]);
            //    }
            //}).Wait();

            Console.WriteLine("With Concurrent Bag");
            ConcurrentBag<int> concurrentBag = new ConcurrentBag<int>();
            int result;
            Task.Run(() =>
            {
                concurrentBag.Add(21);
                concurrentBag.Add(33);
                Thread.Sleep(250);
                concurrentBag.Add(43);
                Thread.Sleep(500);
                concurrentBag.Add(53);
                concurrentBag.TryTake(out result);
                Thread.Sleep(500);
                concurrentBag.Add(63);
            });

            Task.Run(() =>
            {
                foreach (int i in concurrentBag)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(i);
                }
            }).Wait();


        }
    }
}