using System;
using CSharpConcepts.ThreadingConcepts.Interfaces;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Task Factory is created with cetain configuration and can be used to create tasks with that configuration
    /// </summary>
    internal class Concept10 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Task Factory is created with cetain configuration and can be used to create tasks with that configuration");
            Console.WriteLine("==========================================================================================================");
        }

        public void MainMethod()
        {
            Task<Int32[]> parent = Task.Run(() =>
               {
                   var result = new Int32[3];
                   TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                   tf.StartNew(() => result[0] = 1);
                   tf.StartNew(() => result[1] = 2);
                   tf.StartNew(() => result[2] = 2);

                   return result;
               });

            var finalTask = parent.ContinueWith(parentTask =>
            {
                foreach (int i in parent.Result)
                {
                    Console.WriteLine(i);
                }
            });

            finalTask.Wait();
        }
    }
}