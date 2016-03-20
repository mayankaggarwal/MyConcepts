using System;
using CSharpConcepts.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace CSharpConcepts.ProgrammingTests
{
    internal class LargestNumberFromArray : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Find largest number that can be created by combining string from an array");
        }

        public void MainMethod()
        {
            string[] array = { "545", "548", "54", "60", "77","11","0","99","4572" };
            string value = GetLargestNumber(array);

            Console.WriteLine(value);
        }

        public string GetLargestNumber(string[] array)
        {
            string returnVal = "";

            comparatorClass cc = new comparatorClass();
            var list = array.ToList();
            list.Sort(cc);
            list.Reverse();

            foreach (string num in list)
                returnVal += num;
            return returnVal;
        }

        public class comparatorClass : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int Num1 = Int32.Parse(x.ToString() + y.ToString());
                int Num2 = Int32.Parse(y.ToString() + x.ToString());

                return Num1 > Num2 ? 1 : -1;
            }
        }
    }
}