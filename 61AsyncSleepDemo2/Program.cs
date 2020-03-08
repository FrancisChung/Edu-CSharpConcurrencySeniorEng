using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _61AsyncSleepDemo2
{
    class Demonstration
    {
        static async void sleep()
        {
            // wait for three second
            await Task.Delay(3000);
            Console.WriteLine($"Sleep Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sleep();
            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
            //Console.ReadKey();
        }
    }
}