using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
    
namespace _65AsyncSleep3Calls
{

    class Demonstration
    {
        private static int _i;
        static async Task sleep()
        {
            Interlocked.Increment(ref _i);
            Console.WriteLine($"Sleep id {_i}");


            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);

            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);

            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Thread id " + Thread.CurrentThread.ManagedThreadId);
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task t1 = sleep();
            Task t2 = sleep();
            Task t3 = sleep();
            t1.Wait();
            t2.Wait();
            t3.Wait();

            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
        }
    }
}
