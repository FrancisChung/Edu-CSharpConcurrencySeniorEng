using System;
using System.Threading;

namespace _28SemaphorePingPong2
{
    // Can't be solved with a single semaphore
    public class SemaphorePingPongExample2
    {
        Semaphore sem = new Semaphore(0, 1);
        static void Main()
        {
            new SemaphorePingPongExample2().runTest();
            Console.ReadKey();
        }

        void pong()
        {
            while (true)
            {
                sem.WaitOne();
                Console.WriteLine("Pong");
                Thread.Sleep(400);
                sem.Release();
            }
        }


        void ping()
        {
            while (true)
            {
                Console.WriteLine("Ping");
                sem.Release();
                Thread.Sleep(400);

                sem.WaitOne();
            }
        }


        public void runTest()
        {
            Thread pingThread = new Thread(() =>
            {
                ping();
            });


            Thread pongThread = new Thread(() =>
            {
                pong();
            });

            pongThread.Start();
            pingThread.Start();

            pongThread.Join();
            pingThread.Join();
        }
    }
}
