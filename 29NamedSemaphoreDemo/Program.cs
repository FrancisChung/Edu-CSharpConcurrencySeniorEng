using System;
using System.Threading;

namespace _29NamedSemaphoreDemo
{

    class Demonstration
    {
        static void Main()
        {
            new FixedMissedSingal().runTest();
        }
    }

    public class FixedMissedSingal
    {

        public Semaphore sem = new Semaphore(0, 1, "EducativeSemaphore");

        void thread1()
        {
            Semaphore s = Semaphore.OpenExisting("EducativeSemaphore");
            Console.WriteLine("Thread 1 acquiring existing Semaphore");
            s.WaitOne();
            Console.WriteLine("Thread 1 <= Wait1");
        }


        void thread2()
        {
            Console.WriteLine("Thread 2 Open existing Semaphore");

            Semaphore s = Semaphore.OpenExisting("EducativeSemaphore");
            Console.WriteLine("Thread 2 releasing existing Semaphoe");

            s.Release();
        }



        public void runTest()
        {

            Thread t1 = new Thread(() =>
            {
                thread1();
            });

            Thread t2 = new Thread(() =>
            {
                // thread2();
            });

            t2.Start();
            t2.Join();

            t1.Start();
            t2.Join();

            Console.ReadKey();
        }
    }
}
