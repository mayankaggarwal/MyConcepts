using System;
using CSharpConcepts.Interfaces;
using System.Linq;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class LINQExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("LINQ Examples");
        }

        public void MainMethod()
        {
            BasicLINQSelectQuery();
            UsingOrderBy();
            UsingMultipleFromExample();
            UsingLINQOnCustomTypes();
            UsingGroupByAndProjection();
            UsingJoin();
            UsingSkipAndTake();



        }

        private void BasicLINQSelectQuery()
        {
            Console.WriteLine("Basic LINQ select statement with query and method call systax");
            int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Querying with query syntax ");
            var result = from d in data
                         where d % 2 == 0
                         select d;

            Console.WriteLine(String.Join(", ", result));
            Console.WriteLine();
            Console.WriteLine("Quering with method syntax");

            var result1 = data.Where(x => x % 2 == 0);
            foreach (int i in result1)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("The compiler translates the query syntax into a set of method calls.");
            
        }

        private void UsingOrderBy()
        {
            Console.WriteLine("Using Order by to Sort the data");
            int[] data = { 4, 8, 1, 9, 4, 2, 7 };
            var result = from d in data
                         orderby d ascending
                         select d;

            Console.WriteLine(String.Join(", ", data));
        }

        private void UsingMultipleFromExample()
        {
            Console.WriteLine("Using Multiple From statements in LINQ query");
            int[] data1 = { 1, 2, 5 };
            int[] data2 = { 2, 4, 6 };
            var result = from d1 in data1
                         from d2 in data2
                         select d1 * d2;

            Console.WriteLine("Result of multiplication of numbers of 2 arrays :{0}", String.Join(", ", result));
        }

        private void UsingLINQOnCustomTypes()
        {
            Console.WriteLine("Using LINQ capabilities on Custom Types");
            Console.WriteLine("Not implemented");
        }

        private void UsingGroupByAndProjection()
        {
            Console.WriteLine("Not implemented");
        }

        private void UsingJoin()
        {
            Console.WriteLine("Not implemented");
        }

        private void UsingSkipAndTake()
        {
            Console.WriteLine("Not implemented");
        }

    }
}