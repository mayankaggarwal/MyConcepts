using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// System.Threading.Tasks has another class Parallel that can be used for Parallel processing
    /// Parallel class has static methods (For,ForEach and Invoke)
    /// When break is used LowestBreakIteration is set to breaking point but when stop is used it is null
    /// </summary>
    internal class Concept12 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("System.Threading.Tasks has another class Parallel that can be used for Parallel processing");
            Console.WriteLine("Parallel class has static methods (For,ForEach and Invoke)");
            Console.WriteLine("When break is used LowestBreakIteration is set to breaking point but when stop is used it is null");
        }

        public void MainMethod()
        {
            ParallelForLoop();
            ParallelForEachLoop();
            ParallelInvokeMethod();
            BreakingParallel();
            
        }

        private void ParallelInvokeMethod()
        {
            Console.WriteLine("Parallel Invoke not implemented");
        }

        private void ParallelForEachLoop()
        {
            Console.WriteLine("Parallel foreach loop");
            Parallel.ForEach(Enumerable.Range(0, 10), i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            });
        }

        private void ParallelForLoop()
        {
            Console.WriteLine("Parallel for loop");
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
            });
        }

        private void BreakingParallel()
        {
            Console.WriteLine("Breaking Parallel");
            var parallelResult = Parallel.For(0, 500, (int i, ParallelLoopState state) =>
            {
                if (i == 250)
                    state.Break();

                Console.WriteLine(i);
            });

            Console.WriteLine("Break Point :{0}", parallelResult.LowestBreakIteration);
           
        }
    }
}