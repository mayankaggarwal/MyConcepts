using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    internal class Concept21 : IMainMethod
    {
        private volatile static int _flag = 0;
        private static int _value = 0;

        public void SummaryMethod()
        {
            Console.WriteLine("Volatile class example");
            Console.WriteLine("Compiler can change change the order of statements in code and it can create problems in multithreaded execution");
            Console.WriteLine("Volatile class has Special read and write method and it disables the compiler optimizations");
        }

        public void MainMethod()
        {
            var up = Task.Run(() =>
            {
                Thread1();
            });

            var up1 = Task.Run(() =>
            {
                Thread2();
            });
            

            up1.Wait();
            up.Wait();
        }

        public static void Thread1()
        {
            
            _value = 5;
            _flag = 1;
        }

        public static void Thread2()
        {
            if (_flag == 1)
            {
                Console.WriteLine(_value);
            }
        }
    }
}