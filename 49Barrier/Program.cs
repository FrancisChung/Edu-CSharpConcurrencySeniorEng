using System;
using System.Threading;


namespace _49Barrier
{

    class Demonstration
    {
        static void Main()
        {
            new BarrierExample().runTest();
        }
    }

    public class BarrierExample
    {
        Barrier barrier = new Barrier(3, (Barrier barrier) =>
        {
            Console.WriteLine("All threads reached at barrier");
        });


        void work()
        {

            barrier.SignalAndWait();
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " released");
            Thread.Sleep(1000);

            barrier.SignalAndWait();
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " released");
            Thread.Sleep(1000);

            barrier.SignalAndWait();
            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId + " released");
        }

        public void runTest()
        {

            Thread[] threads = new Thread[3];

            for (int i = 0; i < 3; i++)
                threads[i] = new Thread(() =>
                {
                    work();
                });

            for (int i = 0; i < 3; i++)
                threads[i].Start();

            for (int i = 0; i < 3; i++)
                threads[i].Join();

        }
    }
}
