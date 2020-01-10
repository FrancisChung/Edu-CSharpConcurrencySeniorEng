using System;
using System.Threading;

namespace _04ReentrantLockDemo
{
    class ReentrantLockExample
    {
        static void Main()
        {
            Mutex mutex = new Mutex();

            mutex.WaitOne();
            System.Console.WriteLine("Acquired once");

            mutex.WaitOne();
            System.Console.WriteLine("Acquired twice");
        }
    }
}
