using System;
using System.Threading;
namespace _09ThreadPoolThatPrints
{
    class Program
    {
        static void Main(string[] args)
        {
            new ThreadPoolExample().RunTest();
            //Console.ReadKey();
        }
    }

    class ThreadPoolExample
    {
        EventWaitHandle ewh = new EventWaitHandle(false, EventResetMode.AutoReset);
        void Work(object State)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello, is it me you're waiting for?");
            ewh.Set();
        }

        public void RunTest()
        {
            ThreadPool.QueueUserWorkItem(Work);
            ewh.WaitOne();
        }
    }
}
