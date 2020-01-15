using System;
using System.Threading;

namespace _19MutexQ4
{
    class Program
    {
        static void DoImportantWork()
        {
            throw new SystemException();
        }

        static void Main()
        {
            Mutex mutex = new Mutex();

            Thread t1 = new Thread(() => {
                try
                {
                    mutex.WaitOne();
                    DoImportantWork();
                }
                catch (Exception)
                {
                    // swallow exception
                    Console.WriteLine("Swallowing exception");
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            });

            t1.Start();
            t1.Join();

            Console.ReadKey();
        }
    }
}
