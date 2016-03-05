using CSharpConcepts.Interfaces;
using System;
using System.Collections.Concurrent;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Queue also has TryPeek which enables snapshot over iteration
    /// </summary>
    internal class Concept19 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Concurrent Stack and Queue Example");
        }

        public void MainMethod()
        {
            RunConcurrentStack();
            RunConcurrentQueue();
        }

        private void RunConcurrentStack()
        {
            Console.WriteLine("Stack Run implementation along with Range implementations");
            ConcurrentStack<int> stack = new ConcurrentStack<int>();
            stack.Push(10);

            int result;
            if (stack.TryPop(out result))
                Console.WriteLine(result);

            stack.PushRange(new int[] { 1, 2, 3 ,4});

            int[] values = new int[4];
            Console.WriteLine(stack.TryPopRange(values));

            foreach (int num in values) Console.WriteLine(num);
        }

        private void RunConcurrentQueue()
        {
            Console.WriteLine("Queue Run implementation");
            Console.WriteLine("Queue also has TryPeek which enables snapshot over iteration");
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            queue.Enqueue(10);

            int result;
            if (queue.TryDequeue(out result))
                Console.WriteLine(result);
        }
    }
}