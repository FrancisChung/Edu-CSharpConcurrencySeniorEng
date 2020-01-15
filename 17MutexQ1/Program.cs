using System;
using System.Threading;

namespace _17MutexQ1
{
    class Program
    {
        static void Main()
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            mutex.WaitOne();
            Console.WriteLine("Program Exiting");
            mutex.ReleaseMutex();
            mutex.ReleaseMutex();
        }
    }
}
