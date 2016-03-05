using System;
using CSharpConcepts.Interfaces;
using System.Linq;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// PLINQ can be used on objects to potentially turn a sequential query to parallel one
    /// Extension methods for using PLINQ are defined in System.Linq.ParallelEnumerable
    /// Parallel versions of operators : Where,Select,SelectMany,GroupBy,Join,OrderBy,Skip,Take
    /// use withExecuteMethod to specify that PLINQ query should always run  in parallel and withDegreeOfParallelism to specify the number of process
    /// use AsOrdered to get results in order, query is executed in parallel but the results are buffered and sorted
    /// use Sequential to stop your query run in parallel
    /// If a query throws an exception it can be caught using AggregateException
    /// </summary>
    internal class Concept15 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("PLINQ can be used on objects to potentially turn a sequential query to parallel one");
            Console.WriteLine("Extension methods for using PLINQ are defined in System.Linq.ParallelEnumerable");
            Console.WriteLine("Parallel versions of operators : Where,Select,SelectMany,GroupBy,Join,OrderBy,Skip,Take");
            Console.WriteLine("use withExecuteMethod to specify that PLINQ query should always run  in parallel and withDegreeOfParallelism to specify the number of process");
            Console.WriteLine("use AsOrdered to get results in order, query is executed in parallel but the results are buffered and sorted");
            Console.WriteLine("use Sequential to stop your query run in parallel");
            Console.WriteLine("If a query throws an exception it can be caught using AggregateException");
        }

        public void MainMethod()
        {
            BasicPLINQMethod();
            PlinqAsOrderdMethod();
            PlinqAsSequentialMethod();
            PlinqForAllMethod();
            AggregateExceptionExampleMethod();
        }

        private void BasicPLINQMethod()
        {
            Console.WriteLine("Basic Plinq");
            var num = Enumerable.Range(0, 20);
            var parallelResult = num.AsParallel().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }

        private void PlinqAsOrderdMethod()
        {
            Console.WriteLine("As Ordered Example");
            var num = Enumerable.Range(0, 20);
            var parallelResult = num.AsParallel().AsOrdered().Where(i => i % 2 == 0).ToArray();
            foreach (int i in parallelResult)
                Console.WriteLine(i);
        }

        private void PlinqAsSequentialMethod()
        {
            Console.WriteLine("As Sequential Example");
            var num = Enumerable.Range(0, 20);
            var parallelResult = num.AsParallel().Where(i => i % 2 == 0).AsSequential().ToArray();
            foreach (int i in parallelResult.Take(10))
                Console.WriteLine(i);
        }

        private void PlinqForAllMethod()
        {
            Console.WriteLine("Using For All for printing using ForAll");
            var num = Enumerable.Range(0, 20);
            var parallelResult = num.AsParallel().AsOrdered().Where(i => i % 2 == 0);
            parallelResult.ForAll(e => Console.WriteLine(e));
        }

        private void AggregateExceptionExampleMethod()
        {
            Console.WriteLine("Example of Aggregate Exception");
            var num = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = num.AsParallel().Where(i => isEven(i));
                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch(AggregateException exp)
            {
                Console.WriteLine("There were {0} exceptions", exp.InnerExceptions.Count);
            }
        }

        private bool isEven(int i)
        {
            if (i % 10==0) throw new ArgumentException("i");

            return i % 2 == 0;
        }
    }
}