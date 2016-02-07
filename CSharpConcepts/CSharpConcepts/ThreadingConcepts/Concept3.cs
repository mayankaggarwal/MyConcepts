using CSharpConcepts.ThreadingConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Using Parameterized threads
    /// </summary>
    public class Concept3 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Basic Thread initialization");
        }
        public void MainMethod()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }

        private void ThreadMethod(object obj)
        {
            for(int i=0;i<(int)obj;i++)
            {
                Console.WriteLine("Thread Proc :{0}", i);
                Thread.Sleep(0);
            }
        }
    }
}
