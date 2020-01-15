using System;
using System.Threading;

namespace _21MutexQ5
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();

            Thread t1 = new Thread(() =>
            {
                try
                {
                    lock (mutex)
                    {
                        Thread.Sleep(500);
                    }
                }
                catch (Exception)
                {
                    // swallow exception
                    Console.WriteLine("exception swallowed");
                }
            });

            t1.Start();
            t1.Join();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
