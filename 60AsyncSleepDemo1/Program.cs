using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
namespace _60AsyncSleepDemo1
{
    class Demonstration
    {
        static async void sleep()
        {
            // wait for three second
            Thread.Sleep(2000);
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            sleep();
            sw.Stop();
            Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
            Console.ReadKey();
        }
    }
}



