using System;
using System.Threading;
using System.Diagnostics;

namespace _35Monitor
{
    class Program
    {


        class Demonstration
        {
            static void Main()
            {
                Demonstration demo = new Demonstration();
                Stopwatch stopwatch = Stopwatch.StartNew();

                ThreadStart threadStart = new ThreadStart(demo.example);
                Thread thread1 = new Thread(threadStart);
                Thread thread2 = new Thread(threadStart);
                Thread thread3 = new Thread(threadStart);

                thread1.Start();
                Thread.Sleep(500);
                thread2.Start();
                Thread.Sleep(500);
                thread3.Start();

                thread3.Join();
                thread2.Join();
                thread1.Join();

                stopwatch.Stop();
                Console.WriteLine("\n Total execution time of program in seconds : " + stopwatch.ElapsedMilliseconds);
                Console.ReadKey();
            }

            public void example()
            {
                Monitor.Enter(this);

                // Critical section
                Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " enters the critical section.");
                Thread.Sleep(1000);
                Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " exits the critical section.");

                Monitor.Exit(this);
            }

        }
    }
}
