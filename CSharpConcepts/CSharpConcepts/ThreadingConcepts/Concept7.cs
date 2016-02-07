using CSharpConcepts.ThreadingConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Task is an object that represents some work that should be done.
    ///     It can tell if a work is completed and if an operations returns a result.
    ///     Task Schedular is responsible for starting a thread and managing
    /// Attempting to read the Result property on a Task will forse the current thread 
    ///     to wait until Task is finished before continuing
    /// </summary>
    internal class Concept7 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Task is an object that represents some work that should be done.\n"
                    + "It can tell if a work is completed and if an operations returns a result.\n"
                    + "Task Schedular is responsible for starting a thread and managing\n"
                    + "Attempting to read the Result property on a Task will forse the current thread \n"
                    + "to wait until Task is finished before continuing");
        }
        public void MainMethod()
        {
            CreateBasicTask();
        }

        private void CreateBasicTask()
        {
            //Task t = new Task(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write("*");
            //    }
            //});
            //t.RunSynchronously();

            //Task t = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.Write('*');
            //    }
            //});

            Task<int> t = Task.Run<int>(() =>
            {
                return 27;
            });
            Console.WriteLine(t.Result);

            t.Wait();

            
        }
    }
}
