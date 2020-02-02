using System;
using System.Threading;

namespace _47PingPongSpinLock
{
    class Program
    {
        static void Main()
        {
            new PingPongSpinLockExample().runTest();
        }
    }


    public class PingPongSpinLockExample
    {

        private volatile bool flag = false;
        SpinLock sl = new SpinLock();

        void ping()
        {
            while (true)
            {
                bool lockTaken = false;
                sl.Enter(ref lockTaken);

                while (flag)
                {
                    sl.Exit();
                    lockTaken = false;
                    sl.Enter(ref lockTaken);
                }

                Console.WriteLine("Ping");
                Thread.Sleep(400);
                flag = true;

                sl.Exit();
            }
        }


        void pong()
        {
            while (true)
            {
                bool lockTaken = false;
                sl.Enter(ref lockTaken);

                while (!flag)
                {
                    sl.Exit();
                    lockTaken = false;
                    sl.Enter(ref lockTaken);
                }

                Console.WriteLine("Pong");
                Thread.Sleep(400);
                flag = false;

                sl.Exit();
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
