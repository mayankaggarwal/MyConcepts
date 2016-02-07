using System;
using CSharpConcepts.ThreadingConcepts.Interfaces;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// We add Continuation task to the Task Object
    /// The continuation task can hasve configurations which lead to there execution
    /// </summary>
    internal class Concept8 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("We add Continuation task to the Task Object\n"
                + "The continuation task can have configurations which lead to there execution");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        public void MainMethod()
        {
            Method1();
            Method2();
        }

        private void Method1()
        {
            Task<int> t = Task.Run<int>(() =>
            {
                return 42;
            }).ContinueWith((i)=> {
                return i.Result * 2;
            });

            t.Wait();
            Console.WriteLine(t.Result);
        }

        private void Method2()
        {
            Task<int> t = Task<int>.Run(() =>
            {
                return 42;
            });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Cancelled");

            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i)=>
            {
                Console.WriteLine("Faulted");
            },TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i)=>{
                Console.WriteLine("Completed");
            },TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
    }
}