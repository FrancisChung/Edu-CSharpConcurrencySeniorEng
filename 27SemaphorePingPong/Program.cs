using System;
using System.Threading;

namespace _27SemaphorePingPong
{
    class Demonstration
    {
        static void Main()
        {
            new SemaphorePingPongExample().runTest();
            Console.ReadKey();
        }
    }

    public class SemaphorePingPongExample
    {
        Semaphore sem1 = new Semaphore(0, 1);
        Semaphore sem2 = new Semaphore(0, 1);

        void pong()
        {
            while (true)
            {
                sem2.Release();
                sem1.WaitOne();
                Console.WriteLine("Pong");
                Thread.Sleep(400);
            }
        }


        void ping()
        {
            while (true)
            {
                sem2.WaitOne();
                Console.WriteLine("Ping");
                sem1.Release();
                Thread.Sleep(400);
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
