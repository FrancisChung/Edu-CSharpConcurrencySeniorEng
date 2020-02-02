using System;
using System.Threading;

namespace _48PingPongSpinWait
{
    class Demonstration
    {
        static void Main()
        {
            new PingPongSpinWait().runTest();
        }
    }

    public class PingPongSpinWait
    {
        private volatile bool flag = true;

        void ping()
        {
            SpinWait sw = new SpinWait();
            while (true)
            {


                while (flag)
                {
                    sw.SpinOnce();
                }

                Console.WriteLine("Ping");
                //Thread.Sleep(400);
                flag = true;

            }
        }


        void pong()
        {
            while (true)
            {
                SpinWait sw = new SpinWait();
                while (!flag)
                {
                    sw.SpinOnce();
                }

                Console.WriteLine("Pong");
                //Thread.Sleep(400);
                flag = false;
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
