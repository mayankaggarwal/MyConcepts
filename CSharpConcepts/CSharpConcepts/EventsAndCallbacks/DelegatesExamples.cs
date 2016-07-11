using System;
using CSharpConcepts.Interfaces;
using System.IO;
using System.Threading.Tasks;

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
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            StaticAndInstanceDelegateDiff();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            AsyncLambdaExample();
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

        private void StaticAndInstanceDelegateDiff()
        {
            Console.WriteLine("Code to show the difference between Static method assignment and Instance method assignment in delegate");

            Person alice = new Person { Name = "Alice" };
            Person bob = new Person { Name = "Bob" };

            alice.InstanceMethod = alice.GetName;
            alice.StaticMethod = Person.StaticName;

            bob.InstanceMethod = alice.GetName;
            bob.StaticMethod = Person.StaticName;

            string result = "";
            result = String.Format("Alice's Instance method returns: {0} \n"
                + "Alice's Static method returns: {1} \n"
                + "Bob's Instance method returns: {2} \n"
                + "Bob's Static method returns: {3}"
                ,alice.InstanceMethod(),alice.StaticMethod()
                ,bob.InstanceMethod(),bob.StaticMethod());

            Console.WriteLine(result);

        }

        protected class Person
        {
            public string Name;

            public delegate string GetStringDelegate();

            public static string StaticName()
            {
                return "Static";
            }

            public string GetName()
            {
                return Name;
            }

            public GetStringDelegate StaticMethod;
            public GetStringDelegate InstanceMethod;
        }

        private int Trial = 0;
        private void AsyncLambdaExample()
        {
            Form form = new Form();
            //form.ButtonClick += Form_ButtonClick; 
            form.ButtonClick += async (button, buttonArgs) =>
            {
                int trial = ++Trial;
                Console.WriteLine("Running Trial " + trial.ToString() + ".....");
                await DoSomethingAsync();
                Console.WriteLine("Done with Trial " + trial.ToString() + ".....");

            };

            form.OnButtonClick();
        }

        async Task DoSomethingAsync()
        {
            await Task.Delay(3000);
            Console.WriteLine("Timedelay finished");
        }

        public class Form
        {
            public event EventHandler ButtonClick = delegate { };

            public void OnButtonClick()
            {
                ButtonClick(this, EventArgs.Empty);
            }
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