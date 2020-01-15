using System;
using System.Threading;

namespace _25MissedSignal
{
    class Program
    {
        static void Main(string[] args)
        {
            new MissedSignal().runTest();
        }

        public class MissedSignal
        {

            object padlock = new object();

            void thread1()
            {
                Monitor.Enter(padlock);
                Monitor.Wait(padlock);
                Monitor.Exit(padlock);
            }


            void thread2()
            {
                Monitor.Enter(padlock);
                Monitor.Pulse(padlock);
                Monitor.Exit(padlock);
            }



            public void runTest()
            {

                Thread t1 = new Thread(() =>
                {
                    thread1();
                });

                Thread t2 = new Thread(() =>
                {
                    thread2();
                });

                t2.Start();
                t2.Join();

                t1.Start();
                t2.Join();
            }
        }
    }


}
