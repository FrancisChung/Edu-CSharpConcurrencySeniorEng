using System;
using System.Threading;


namespace _45LockPingPong
{

    class Demonstration
    {
        private readonly object padlock = new object();
        private bool flag = false;

        void ping()
        {
            while (true)
            {

                lock (padlock)
                {
                    while (flag)
                    {
                        Monitor.Wait(padlock);
                    }

                    Console.WriteLine("Ping");
                    Thread.Sleep(400);
                    flag = true;
                    Monitor.Pulse(padlock);
                }
            }
        }


        void pong()
        {
            while (true)
            {

                lock (padlock)
                {
                    while (!flag)
                    {
                        Monitor.Wait(padlock);
                    }

                    Console.WriteLine("Pong");
                    Thread.Sleep(400);
                    flag = false;
                    Monitor.Pulse(padlock);
                }
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
        }
    }
}
