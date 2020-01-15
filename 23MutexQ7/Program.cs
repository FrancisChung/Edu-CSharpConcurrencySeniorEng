using System;
using System.Threading;

namespace _23MutexQ7
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();

            Thread t1 = new Thread(() =>
            {
                mutex.WaitOne();
                mutex.WaitOne();
                mutex.ReleaseMutex();
                //mutex.ReleaseMutex();

            });

            t1.Start();
            t1.Join();

            // Main thread attemps to acquire the mutex
            mutex.WaitOne();
            Console.WriteLine("All Good");
            mutex.ReleaseMutex();
            Console.ReadKey();
        }
    }
}
