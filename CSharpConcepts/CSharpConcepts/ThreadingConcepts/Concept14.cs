using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpConcepts.ThreadingConcepts
{
    internal class Concept14 : IMainMethod
    {
        public void MainMethod()
        {
            CallMethod1();
            CallMethod2();
        }

        private void CallMethod2()
        {
            throw new NotImplementedException();
        }

        public Task SleepAsyncA(int milliSeconds)
        {
            return Task.Run(() => { Thread.Sleep(milliSeconds); });
        }

        public Task SleepAsyncB(int milliSeconds)
        {
            TaskCompletionSource<int> tcs = null;
            Timer timer = new Timer(delegate { tcs.TrySetResult(10); }, null, -1, -1);
            tcs = new TaskCompletionSource<int>(timer);
            timer.Change(milliSeconds, -1);
            return tcs.Task;
        }

        private void CallMethod1()
        {
            throw new NotImplementedException();
        }

        public void SummaryMethod()
        {
            throw new NotImplementedException();
        }
    }
}