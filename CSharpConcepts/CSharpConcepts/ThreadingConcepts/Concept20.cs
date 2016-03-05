using System;
using CSharpConcepts.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpConcepts.ThreadingConcepts
{
    internal class Concept20 : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Synchornization Examples");
        }

        public void MainMethod()
        {
            AccessgingSameDataExample();
            UsingLockObject();
            DeadlockExample();
            InterlockedClassExample();
            InterlockedCompareExchangeExample();
           
        }

        private void AccessgingSameDataExample()
        {
            Console.WriteLine("Operation with multithreading issue : Accessing same variable in 2 threads:");
            int n = 0;

            Task u = Task.Run(() =>
            {
                for(int i=0;i<1000000;i++)
                {
                    n++;
                }
            });

            for(int i=0;i<1000000;i++)
            {
                n--;
            }

            u.Wait();
            Console.WriteLine(n);
        }

        private void UsingLockObject()
        {
            Console.WriteLine("Operation using lock object for synchronizig accessing shared data");
            Console.WriteLine("Using lock operator compiler translates in a call to System.Thread.Monitor");
            Console.WriteLine("It can cause threads to block while they are waiting for each other and can cause deadlock");
            Console.WriteLine("It is important to use lock statement with reference object that is private to class");
            Console.WriteLine("it should be reference type because value type will get boxed each time we acquire a lock and generates a new lock each time losing locking mechanism");
            Console.WriteLine("We should not use this variable because that variable could be used by other code to create a lock,causing deadlocks");
            Console.WriteLine("Lock should be used on string because compiler can create one object for several strings having same content");
            int n = 0;

            object _lock = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (_lock)
                        n++;
                }
            });

            for(int i=0;i<1000000;i++)
            {
                lock(_lock)
                    n--;
            }

            up.Wait();
            Console.WriteLine(n);
        }

        private void DeadlockExample()
        {
            Console.WriteLine("Deadlocks can be avoided by making sure that locks are requested in same order");
            Console.WriteLine("Dead scenario");
            object _lockA = new object();
            object _lockB = new object();

            var up = Task.Run(() =>
            {
                lock (_lockA)
                {
                    Thread.Sleep(1000);
                    lock (_lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock(_lockB)
            {
                 lock(_lockA)
                {
                    Console.WriteLine("Locked B and A");
                }
            }

            up.Wait();

        }

        private void InterlockedClassExample()
        {
            Console.WriteLine("Interlocked class example");
            Console.WriteLine("Making operations atomic is the job of Interlocked class");
            Console.WriteLine("Increment,Decrement, Add , CompareExhange and Interlocked.Exchange are its operations");

            int n = 0;
            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                    Interlocked.Increment(ref n);
            });

            for (int i = 0; i < 1000000; i++)
                Interlocked.Decrement(ref n);

            Console.WriteLine(n);
            up.Wait();
        }

        private void InterlockedCompareExchangeExample()
        {
            Console.WriteLine("Interlocked compare example");
            Console.WriteLine("It makes sure that  comparing the value and exchaning it to new one is an atomic operation");
            int value = 1;
            Task t1 = Task.Run(() =>
            {
                if (value == 1)
                {
                    Thread.Sleep(1000);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine(value);
        }
    }
}