using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    public class Concept1:IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Basic Thread initialization");
        }

        private void ThreadMethod()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }

        public void MainMethod()
        {
            Thread thread = new Thread(ThreadMethod);
            thread.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread: Do some Work");
                Thread.Sleep(0);
            }
            thread.Join();
        }
    }
}
