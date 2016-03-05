using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Tasks can also have child tasks. Parent Tasks finished when all child tasks are ready
    /// Final Task only runs when the parent task is finished and parent task only runs when all child taks finishes;
    /// </summary>
    internal class Concept9 : IMainMethod
    {
        public void MainMethod()
        {
            Task<Int32[]> parent = Task.Run(()=>
            {
                var result = new Int32[3];

                new Task(() => result[0] = 0, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[1] = 1, TaskCreationOptions.AttachedToParent).Start();
                new Task(() => result[2] = 2, TaskCreationOptions.AttachedToParent).Start();

                return result;
            });
            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int i in parentTask.Result)
                {
                    Console.WriteLine(i);
                }
            });
            finalTask.Wait();

        }

        public void SummaryMethod()
        {
            Console.WriteLine("Tasks can also have child tasks. Parent Tasks finished when all child tasks are ready");
            Console.WriteLine("Final Task only runs when the parent task is finished and parent task only runs when all child taks finishes;");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
    }
}