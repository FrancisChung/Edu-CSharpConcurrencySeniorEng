using System;
using System.Threading;

namespace _24SemaphoreFullException
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore sem = new Semaphore(0, 1);
            sem.Release();
            sem.Release();
            Console.ReadKey();
        }


    }
}
