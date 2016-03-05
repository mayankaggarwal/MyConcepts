using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Thread.Abort can create exceptions for stopping the thread;
    /// Using Shared variables to stop the threads
    /// </summary>
    public class Concept4 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Thread.Abort can create exceptions for stopping the thread \n Using Shared variables to stop the threads");
        }
        public void MainMethod()
        {
            bool stopped = false;
            Thread t = new Thread(new ThreadStart(() =>
            {
                while(!stopped)
                {
                    Console.WriteLine("Running");
                    Thread.Sleep(500);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to stop");

            Console.ReadKey();
            stopped = true;
            t.Join();
        }
    }
}
