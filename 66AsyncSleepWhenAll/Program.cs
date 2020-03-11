using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _66AsyncSleepWhenAll
{
    class Demonstration
    {
        static async Task sleep()
        {
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
        1
        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task superSleep = SuperSleep();
            superSleep.Wait();

            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
        }

        private static async Task SuperSleep()
        {
            Task t1 = sleep();
            Task t2 = sleep();
            Task t3 = sleep();

            Task combinedTask = Task.WhenAll(t1, t2, t3);
            await combinedTask;
        }
    }
}
