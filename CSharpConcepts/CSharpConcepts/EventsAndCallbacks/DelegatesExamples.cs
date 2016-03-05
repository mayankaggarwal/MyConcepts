using System;
using CSharpConcepts.Interfaces;
using System.IO;

namespace CSharpConcepts.EventsAndCallbacks
{
    internal class DelegatesExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Delegates Example");
        }

        public void MainMethod()
        {
            BasicDelegateEg();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            MulticastDelegateExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            CovarianceDelegateExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            ContraVarianceDelegateExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            DelegateWithLambdaExpression();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            ActionDelegateExample();

        }

        private void BasicDelegateEg()
        {
            Console.WriteLine("Basic Delegate:");
            Calculate calc = Add;
            Console.WriteLine(calc(5, 7));
            calc = Multiply;
            Console.WriteLine(calc(5, 7));
            calc += Add;
            Console.WriteLine(calc(7, 5));
        }

        private void MulticastDelegateExample()
        {
            Console.WriteLine("Multicast Delegate Example:");
            Del del = Method1;
            Console.WriteLine("Attaching second method using +=");
            del += Method2;
            del();

        }

        private void CovarianceDelegateExample()
        {
            Console.WriteLine("Covariance Delegate Example");
            Console.WriteLine("Covariance makes it possible that a method has a return type that is more derived than that of delegate.");
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }

        private void ContraVarianceDelegateExample()
        {
            Console.WriteLine("ContraVariance Delegate Example");
            Console.WriteLine("Contra-variance permits a method that has parameter types that are less derived than those in delegate type.");
            ContraVarianceDel del;
            del = DoSomething;
        }

        private void DelegateWithLambdaExpression()
        {
            Console.WriteLine("Delegates with Lambda expressions");
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(10, 20));
            calc = (x, y) => x * y;
            Console.WriteLine(calc(5, 7));
            calc = (x, y) =>
            {
                Console.WriteLine("Adding Numbers in Multiline anonymous block");
                return x + y;
            };
            Console.WriteLine(calc(2, 3));
        }

        private void ActionDelegateExample()
        {
            Console.WriteLine("Action delegate example where it is passed to another method as a parameter");
            Action<int, int> calc = (x, y) =>
             {
                 Console.WriteLine(x + y);
             };
            DelegateInvoker(calc);
        }

        private void DelegateInvoker(Action<int,int> del)
        {
            del(5,6);
        }

        #region Supporting methods
        public delegate int Calculate(int x, int y);
        public int Add(int x,int y) { return x + y; }
        public int Multiply(int x,int y) { return x * y; }


        public delegate void Del();
        public void Method1() { Console.WriteLine("MethodOne"); }
        public void Method2() { Console.WriteLine("MethodTwo"); }

        public delegate TextWriter CovarianceDel();
        public StreamWriter MethodStream() { return null; }
        public StringWriter MethodString() { return null; }

        public delegate void ContraVarianceDel(StreamWriter tw);
        public void DoSomething(TextWriter tw) { }
        #endregion
    }
}