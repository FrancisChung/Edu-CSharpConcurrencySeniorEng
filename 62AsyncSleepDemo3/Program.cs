using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _62AsyncSleepDemo3
{
    class Demonstration
    {
        static async Task sleep()
        {
            // wait for 3 seconds
            Console.WriteLine("Sleep Thread id before: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Sleep Thread id after: " + Thread.CurrentThread.ManagedThreadId);
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Sleep Task startingx");
            Task sleepTask = sleep();
            Console.WriteLine("About to wait in main method for sync sleep method to finish.");
            sleepTask.Wait();
            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");

        }
    }
}
