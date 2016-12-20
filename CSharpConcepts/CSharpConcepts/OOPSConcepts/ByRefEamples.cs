using CSharpConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpConcepts.OOPSConcepts
{
    public class ByRefEamples:IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Reference type examples");
        }

        public void MainMethod()
        {
            NewOperatorEffect();
        }

        private void NewOperatorEffect()
        {
            Prod a = new Prod();
            a.Name = "A";
            a.ID = 1;

            Prod b;
            b = a;

            Console.WriteLine("Before changing anything");
            Console.WriteLine("Value fo Prod A: Name = {0}, ID = {1}", a.Name, a.ID);
            Console.WriteLine("Value fo Prod B: Name = {0}, ID = {1}", b.Name, b.ID);

            a.Name = "Updated A";
            a.ID = 2;

            Console.WriteLine("After changing value of a");
            Console.WriteLine("Value fo Prod A: Name = {0}, ID = {1}", a.Name, a.ID);
            Console.WriteLine("Value fo Prod B: Name = {0}, ID = {1}", b.Name, b.ID);

            b.Name = "Updated B";
            b.ID = 3;

            Console.WriteLine("After changing value of b");
            Console.WriteLine("Value fo Prod A: Name = {0}, ID = {1}", a.Name, a.ID);
            Console.WriteLine("Value fo Prod B: Name = {0}, ID = {1}", b.Name, b.ID);

            a = new Prod { Name = "Updated a with new", ID = 4 };

            Console.WriteLine("After changing value of a with new operator");
            Console.WriteLine("Value fo Prod A: Name = {0}, ID = {1}", a.Name, a.ID);
            Console.WriteLine("Value fo Prod B: Name = {0}, ID = {1}", b.Name, b.ID);

        }


        public class Prod
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
    }
}
