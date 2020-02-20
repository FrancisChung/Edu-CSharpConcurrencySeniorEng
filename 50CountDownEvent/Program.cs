using System;
using System.Threading;

namespace _50CountDownEvent
{
    class Demonstration
    {
        static void Main()
        {
            new CountDownEventExample().runTest();
            Console.ReadKey();
        }
    }

    public class CountDownEventExample
    {

        CountdownEvent cde = new CountdownEvent(3);

        void getBlocked()
        {
            cde.Wait();
            Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " released");
        }


        public void runTest()
        {

            Thread t1 = new Thread(() =>
            {
                Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " started");
                getBlocked();
            });

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " started");
                getBlocked();
            });

            t1.Start();
            t2.Start();

            Thread.Sleep(1000);

            Console.WriteLine("CountDownEvent signaled");
            cde.Signal();
            Thread.Sleep(500);
            Console.WriteLine("CountDownEvent signaled");
            cde.Signal();
            Thread.Sleep(500);
            Console.WriteLine("CountDownEvent signaled");
            cde.Signal();
            Thread.Sleep(500);

            cde.Wait();

            t1.Join();
            t2.Join();
        }

    }
}
