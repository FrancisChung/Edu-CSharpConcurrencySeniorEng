using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _63AsyncSleepTask
{
    class Demonstration
    {
        static async Task<String> sleep()
        {
            // wait for 3 seconds
            Console.WriteLine("Thread id before: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(3000);
            Console.WriteLine("Thread id after: " + Thread.CurrentThread.ManagedThreadId);
            return "I slept well!";
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Task<String> sleepTask = sleep();
            Console.WriteLine("About to wait in main method for sync sleep method to finish.");
            String retVal = sleepTask.Result;
            sw.Stop();
            Console.WriteLine("Received from asyn method " + retVal);
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
        }
    }
}
