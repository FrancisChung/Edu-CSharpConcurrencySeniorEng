using System;
using System.Threading;

namespace _22MutexQ6
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mutex = new Mutex())
            {
                mutex.WaitOne();
                Console.WriteLine("WaitOne");
                Thread.Sleep(500);
                mutex.ReleaseMutex();
                Console.WriteLine("ReleaseMutex");
            }
            Console.ReadKey();
        }
    }
}
