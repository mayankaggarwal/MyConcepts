using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Use Wait all to wait for multiple tasks to finish before continuing execution
    /// Use WhenAll method that can use to schedule a continuation method after all Tasks have finished
    /// Use WaitAny method which is used to wait until one of the tasks is finished
    /// </summary>
    internal class Concept11 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Use Wait all to wait for multiple tasks to finish before continuing execution");
            Console.WriteLine("Use WhenAll method that can use to schedule a continuation method after all Tasks have finished");
            Console.WriteLine("Use WaitAny method which is used to wait until one of the tasks is finished");
            Console.WriteLine("=================================================================================================");
        }

        public void MainMethod()
        {
            Method1();
            Method2();
        }

        private void Method1()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            Task.WaitAll(tasks);
        }

        private void Method2()
        {
            Task<int>[] tasks = new Task<int>[3];

            tasks[0] = Task.Run(() => { Thread.Sleep(1000); return 0; });
            tasks[1] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[2] = Task.Run(() => { Thread.Sleep(3000); return 2; });

            while(tasks.Length>0)
            {
                int i = Task.WaitAny(tasks);
                Task<int> completedTask = tasks[i];
                Console.WriteLine(completedTask.Result);

                var temp = tasks.ToList();
                temp.RemoveAt(i);
                tasks = temp.ToArray();
            }
        }

    }
}