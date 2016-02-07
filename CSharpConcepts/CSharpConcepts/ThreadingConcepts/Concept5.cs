using CSharpConcepts.ThreadingConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpConcepts.ThreadingConcepts
{
    /// <summary>
    /// A thread has its own call stack that stores all the methods that are executed.
    /// Local variables are stored on call stack and are private to thread.
    /// By marking a field as ThreadStatic attribute and also making it static, each thread get its own copy of field
    /// </summary>
    public class Concept5 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("A thread has its own call stack that stores all the methods that are executed.\n"
                + "Local variables are stored on call stack and are private to thread.\n"
                + "By marking a field as ThreadStatic attribute and also making it static, each thread get its own copy of field");
        }

        [ThreadStatic]
        public static int _field;

        public ThreadLocal<int> _field1 = new ThreadLocal<int>(() =>
        {
            return Thread.CurrentThread.ManagedThreadId;
        });

        public void MainMethod()
        {
            SharingMethodWithoutInitialization();
            LocalVariableWithInitialization();
        }

        private void LocalVariableWithInitialization()
        {
            new Thread(() =>
            {
                for (int i = 0; i < _field1.Value; i++)
                {
                    _field++;
                    Console.WriteLine("LocalVariableWithInitialization Thread 1 Field :{0}", i);
                }

            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < _field1.Value; i++)
                {
                    _field++;
                    Console.WriteLine("LocalVariableWithInitialization Thread 2 Field :{0}",i);
                }
            }).Start();

        }

        private void SharingMethodWithoutInitialization()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Main Thread 1 Field :{0}", _field);
                }

            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Main Thread 2 Field :{0}", _field);
                }
            }).Start();

        }
    }
}
