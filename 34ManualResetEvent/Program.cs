using System;
using System.Threading;

namespace _34ManualResetEvent
{
    class Program
    {


        class Demonstration
        {
            static void Main()
            {
                new EventWaitHandleExample().runTest();
                Console.ReadKey();
            }
        }

        public class EventWaitHandleExample
        {
            ManualResetEvent mre1 = new ManualResetEvent(false);
            ManualResetEvent mre2 = new ManualResetEvent(false);


            void work(int num)
            {
                mre1.WaitOne();
                Console.WriteLine(num * num);

                mre2.Set();
            }

            public void runTest()
            {

                Thread t1 = new Thread(() =>
                {
                    work(5);
                });

                Thread t2 = new Thread(() =>
                {
                    work(10);
                });

                t1.Start();
                t2.Start();

                Thread.Sleep(1000);


                mre1.Set();
                mre2.WaitOne();
                //mre1.WaitOne();

                Console.WriteLine("Main thread exiting");


            }
        }
    }
}
