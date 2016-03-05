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
    /// If IsBackgraound property set to true the application exits immediately
    /// if IsBackground is set to false the application prints everything
    /// Application should not have Console.ReadLine()
    /// </summary>
    public class Concept2 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("If IsBackgraound property set to true the application exits immediately\n"
                        + "if IsBackground is set to false the application prints everything\n"
                        + "Application should not have Console.ReadLine()");
        }

        public void MainMethod()
        {
            Thread thread = new Thread(new ThreadStart(ThreadMethod));
            thread.IsBackground = true;
            thread.Start();
            //for(int i=0;i<4;i++)
            //{
            //    Console.WriteLine("Main thread :{0}", i);
            //    Thread.Sleep(0);
            //}
            //Console.WriteLine();

        }

        private void ThreadMethod()
        {
            for(int i=0;i<100000;i++)
            {
                Console.WriteLine("ThreadProc :{0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
