using CSharpConcepts.Interfaces;
using System;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// Task is an object that represents some work that should be done.
    ///     It can tell if a work is completed and if an operations returns a result.
    ///     Task Schedular is responsible for starting a thread and managing
    /// Attempting to read the Result property on a Task will forse the current thread 
    ///     to wait until Task is finished before continuing
    ///     http://blogs.msdn.com/b/pfxteam/archive/2011/10/24/10229468.aspx
    ///     http://blogs.msdn.com/b/pfxteam/archive/2010/06/13/10024153.aspx
    ///     http://blog.stephencleary.com/2013/08/startnew-is-dangerous.html
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
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            CreateBasicTaskUsingTaskFactory();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            CreateBasicTaskUsingRun();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }

        private void CreateBasicTask()
        {
            //Task t1 = new Task(() =>
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

            //t.Wait();

            Task<int> t2 = new Task<int>(()=>taskrun("Mayank"));
            t2.Start();
            Console.WriteLine("Object of task is created where are parameter is passed and return value is:{0}", t2.Result);
            
        }

        private void CreateBasicTaskUsingTaskFactory()
        {
            Task<int> t = Task.Factory.StartNew<int>(() =>
                {
                    return 42;
                });

            Console.WriteLine("Return from Task.Factory initiation is :{0}", t.Result);

            var t1 = Task.Factory.StartNew(() =>
                {
                    Task<int> inner = Task.Factory.StartNew(() => 42);
                    return inner;
                });

            Console.WriteLine("Return from taskfactory with inner task :{0}", t1.Result.Result);
            var t2 = Task.Factory.StartNew(async delegate
            {
                await Task.Delay(1000);
                return 42;
            }).Unwrap();

            Console.WriteLine("Return from async , await and unwrap Task.Factory method :{0}", t2.Result);
        }

        private void CreateBasicTaskUsingRun()
        {
            Task<int> t = Task.Run<int>(() =>
                {
                    return 42;
                }
            );
            Console.WriteLine("Return from Task.Run initiation is :{0}", t.Result);

            var t1 = Task.Run(() =>
                {
                    Task<int> inner = Task.Run<int>(() => 42);
                    return inner;
                });
            Console.WriteLine("Return of Task.Run with inner task is :{0}", t1.Result);

            var t2 = Task.Run(async () =>
                {
                    await Task.Delay(1000);
                    return 42;
                });
            Console.WriteLine("Return from async, await and without unwrap Task.run is :{0}", t2.Result);
        }

        private int taskrun(string name)
        {
            Console.WriteLine("Called as Parameterized Method with name: {0}", name);
            return 22;
        }
    }
}
