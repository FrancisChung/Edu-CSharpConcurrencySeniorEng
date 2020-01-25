using System;
using System.Threading;

namespace _38PingPongMonitor
{

class Demonstration
    {
        private readonly object padlock = new object();
        private bool flag = false;

        void ping()
        {
            while (true)
            {

                Monitor.Enter(padlock);

                while (flag)
                {
                    Monitor.Wait(padlock);
                }

                Console.WriteLine("Ping");
                Thread.Sleep(400);
                flag = true;
                Monitor.Pulse(padlock);

                Monitor.Exit(padlock);
            }
        }


        void pong()
        {
            while (true)
            {

                Monitor.Enter(padlock);

                while (!flag)
                {
                    Monitor.Wait(padlock);
                }

                Console.WriteLine("Pong");
                Thread.Sleep(400);
                flag = false;
                Monitor.Pulse(padlock);

                Monitor.Exit(padlock);
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

        static void Main()
        {
            new Demonstration().runTest();
            Console.ReadKey();
        }
    }
}
