using System;
using System.Threading;

namespace _31InterlockedPingPong
{


    class Demonstration
    {
        static void Main()
        {
            new PingPongInterlockedExample().runTest();
            Console.ReadKey();
        }
    }

    public class PingPongInterlockedExample
    {
        long flag = 1;

        void ping()
        {
            while (true)
            {
                while (Interlocked.Read(ref flag) == 1) { }

                Console.WriteLine("Ping");
                Thread.Sleep(400);
                Interlocked.Exchange(ref flag, 1);

            }
        }


        void pong()
        {
            while (true)
            {
                while (Interlocked.Read(ref flag) == 0) { }

                Console.WriteLine("Pong");
                Thread.Sleep(400);
                Interlocked.Exchange(ref flag, 0);
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


            pingThread.IsBackground = true;
            pongThread.IsBackground = true;

            pingThread.Start();
            pongThread.Start();

            Thread.Sleep(1000);
        }
    }
}
