using System;
using System.Threading;
using System.Threading.Tasks;

namespace _55TaskContinuationDemo
{
    class Demonstration
    {
        static void Main()
        {
            Task task1 = Task.Factory.StartNew((object obj) =>
            {
                Console.WriteLine("Hello " + obj);
                Console.WriteLine("First task executed by thread with id " + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);

            }, "Reader");

            Task task2 = task1.ContinueWith((prevTask) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Second task in progress");
                Console.WriteLine("Second task executed by thread with id " + Thread.CurrentThread.ManagedThreadId);
            });

            Thread.Sleep(100);

            Task.WaitAll(task1, task2);
            Console.WriteLine("Both tasks finished");
            Console.ReadKey();
        }
    }
}
