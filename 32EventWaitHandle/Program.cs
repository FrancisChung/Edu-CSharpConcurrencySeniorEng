using System;
using System.Threading;

namespace _32EventWaitHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            new EventWaitHandleDemo().runTest();
            Console.ReadKey();
        }
    }

    public class EventWaitHandleDemo
    {
        EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.ManualReset);
        EventWaitHandle done = new EventWaitHandle(false, EventResetMode.AutoReset);

        void Work(int num)
        {
            ewh.WaitOne();
            Thread.Sleep(400);
            Console.WriteLine($"Result :{num * num}");

            done.Set();
        }

        public void runTest()
        {

            Thread t1 = new Thread(() => {
                Work(5);
            });

            Thread t2 = new Thread(() => {
                Work(10);
            });

            t1.Start();
            Console.WriteLine("Thread 1 started");
            t2.Start();
            Console.WriteLine("Thread 2 started");


            //Thread.Sleep(1000);

            Console.WriteLine("Signal&Waiting");

            WaitHandle.SignalAndWait(ewh, done);

            Console.WriteLine("Main thread exiting");

            t1.Join();
            t2.Join();

            

        }
    }
}
