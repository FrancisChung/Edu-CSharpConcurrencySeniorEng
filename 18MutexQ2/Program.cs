using System;
using System.Threading;

namespace _18MutexQ2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();
            mutex.WaitOne();
            Console.WriteLine("Program Exiting");
        }
    }
}
