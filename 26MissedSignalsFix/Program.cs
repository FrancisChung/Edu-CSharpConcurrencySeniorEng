using System;
using System.Threading;

namespace _26MissedSignalsFix
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

        Semaphore sem = new Semaphore(0, 1);

        void thread1()
        {
            Console.WriteLine("WaitOne Pre");
            sem.WaitOne();
            Console.WriteLine("WaitOne Post");

        }


        void thread2()
        {

            sem.Release();
        }



        public void runTest()
        {

            Thread t1 = new Thread(() =>
            {
                thread1();
            });

            Thread t2 = new Thread(() =>
            {
                thread2();
            });

            t2.Start();
            t2.Join();

            t1.Start();
            t2.Join();

            Console.ReadKey();
        }
    }
}
