using System;
using System.Threading;

namespace _19MutexQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.Version);

            Mutex mutex = new Mutex();
            Thread t1 = new Thread(() => {

                mutex.WaitOne();
                Console.WriteLine("t1 exiting");
            });
            t1.Start();
            t1.Join();

            Thread t2 = new Thread(() => {
                mutex.WaitOne();
                Console.WriteLine("t2 exiting");
            });
            t2.Start();
            t2.Join();
        }
    }
}
