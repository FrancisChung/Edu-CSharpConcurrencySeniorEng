using System;
using System.Threading;

namespace _08ThreadPoolDoesntPrint
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
        void Work(object State)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Hello, is it me you're waiting for?");
        }

        public void RunTest()
        {
            ThreadPool.QueueUserWorkItem(Work);
        }
    }
}
