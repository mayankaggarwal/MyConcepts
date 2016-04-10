using System;
using CSharpConcepts.Interfaces;
using System.Threading;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// While using Thread Pool, we queue a work item that is then picked up by an avilable thread from the pool.
    /// The thread pool ensures that each request gets added to queue and that when a thread becomes avaiable, it is processed.
    /// As threads are being reused , they also resue their local state. 
    /// In queue work item there is no way to determine when the operation is finished and what was the return value;
    /// </summary>
    internal class Concept6 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("While using Thread Pool, we queue a work item that is then picked up by an avilable thread from the pool.\n"
                + "The thread pool ensures that each request gets added to queue and that when a thread becomes avaiable, it is processed.\n"
                + "As threads are being reused , they also resue their local state.\n"
                + "In queue work item there is no way to determine when the operation is finished and what was the return value;");
        }

        public void MainMethod()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            ThreadPool.QueueUserWorkItem(ThreadPoolRun);
        }

        private void ThreadPoolRun(object state)
        {
            Console.WriteLine("Running from thread pool");
        }
    }
}