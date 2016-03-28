using System;
using CSharpConcepts.Interfaces;
using System.Threading;

namespace CSharpConcepts.DebugingConcepts
{
    internal class ReleaseAndDebugDiffExecution : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Execution of code will behave differently for debug and release mode");
            Console.WriteLine("In debugging mode the callback is executed regulary while in release mode the callback executes only once");
            Console.WriteLine("In release mode the compiler optimizes the code.It sees that the timer object is not used anymore, so its no longer considered a root object and GC removes it from memory");
            Console.WriteLine("In Debug mode, the ompiler inserts extra no-operation (NOP) instructions and branch instructions");
        }

        public void MainMethod()
        {
            Timer t = new Timer(TimerCallBack, null, 0, 2000);
            Console.ReadLine();
        }

        private void TimerCallBack(object state)
        {
            Console.WriteLine("In Timer Callback :{0}", DateTime.Now);
            GC.Collect();
        }
    }
}