using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _64AsyncSleep3Awaits
{
    class Demonstration
    {
        static async Task sleep()
        {

            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Await Thread id " + Thread.CurrentThread.ManagedThreadId);

            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Await Thread id " + Thread.CurrentThread.ManagedThreadId);

            // wait for 1 second
            await Task.Delay(1000);
            Console.WriteLine("Await Thread id " + Thread.CurrentThread.ManagedThreadId);
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task sleepTask = sleep();
            sleepTask.Wait();
            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");

        }
    }
}
