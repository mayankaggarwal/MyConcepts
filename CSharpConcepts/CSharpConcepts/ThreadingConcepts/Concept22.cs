using System;
using CSharpConcepts.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    internal class Concept22 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Cancellation task examples");
        }

        public void MainMethod()
        {
            CancellationTaskExample1();
            CancellationTaskExample2();
            CancellationtaskExample3();
            CancellationTaskExample4();
        }

        private void CancellationTaskExample1()
        {
            Console.WriteLine("Simple Cancellation Task Example:");
            Console.WriteLine("CancellationToken is used in asynchronous tasks");
            Console.WriteLine("CancellationTokenSource is used to signal that the task should cancel itself");

            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            CancellationToken token = cancellationToken.Token;

            Task tak = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("The task has been cancelled");
            },token);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();
            cancellationToken.Cancel();

            Console.WriteLine("Press enter to end the example");
            Console.ReadLine();


        }

        private void CancellationTaskExample2()
        {
            Console.WriteLine("If we want to signal outside users that our task has been cancelled, we can do this by throwing an exception OperationCancelledException");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task t1 = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }

                token.ThrowIfCancellationRequested();
            }, token);

            try
            {
                Console.WriteLine("Press enter to stop the execution");
                Console.ReadLine();

                cancellationTokenSource.Cancel();
                //t1.Wait();
            }
            catch(AggregateException exp)
            {
                Console.WriteLine(exp.InnerExceptions[0].Message);
            }

            Console.WriteLine("Press enter to end the example");
            Console.ReadLine();
        }

        private void CancellationtaskExample3()
        {
            Console.WriteLine("Instead of catching the exception we can also add continuation task that gets executed only when task is cancelled");

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token).ContinueWith((t) =>
             {
                 //t.Exception.Handle((e) => true);
                 Console.WriteLine("You have cancelled the task");
             }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to cancel the task");
            Console.ReadLine();

            tokenSource.Cancel();

            Console.WriteLine("Press enter to end the example");
            Console.ReadLine();
        }

        private void CancellationTaskExample4()
        {
            Console.WriteLine("Task timeout example");
            Console.WriteLine("if returned index from Task.waintAny is -1 than the task is timed out.");
            Task longrunning = Task.Run(() =>
            {
                Thread.Sleep(100000);
            });

            int index = Task.WaitAny(new[] { longrunning }, 1000);
            if (index == -1)
                Console.WriteLine("task timed out");
        }
    }
}