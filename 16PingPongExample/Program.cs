using System;
using System.Threading;

namespace _16PingPongExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            new PingPongExample().Test();
            Console.ReadKey();
        }

        class PingPongExample
        {
            Mutex mutex = new Mutex();
            bool flag = false;

            public void Ping()
            {
                mutex.WaitOne();

                while (flag)
                {
                    mutex.ReleaseMutex();

                    mutex.WaitOne();
                }

                Console.WriteLine("Ping");
                flag = true;
                Thread.Sleep(100);


                mutex.ReleaseMutex();
            }

            public void Pong()
            {
                mutex.WaitOne();

                while(!flag)
                {
                    mutex.ReleaseMutex();
                    mutex.WaitOne();
                }

                Console.WriteLine("Pong");
                flag = false;
                Thread.Sleep(100);

                mutex.ReleaseMutex();
            }

            public void Test()
            {
                while (true)
                {
                    var pingThread = new Thread(() => { Ping(); });
                    pingThread.IsBackground = true;
                    var pongThread = new Thread(() => { Pong(); });
                    pongThread.IsBackground = true;

                    pingThread.Start();
                    pongThread.Start();
                    Thread.Sleep(500);
                }

            }
        }
    }
}
