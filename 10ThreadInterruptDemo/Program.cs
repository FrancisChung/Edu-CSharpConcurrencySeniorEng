using System;
using System.Threading;

namespace _10ThreadInterruptDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new ThreadAbortExample().runTest();
            Console.ReadKey();
        }

        public class ThreadAbortExample
        {

            void childThread()
            {

                try
                {
                    Console.WriteLine("Child Thread Started");
                    Thread.Sleep(Timeout.Infinite);
                }
                catch (ThreadInterruptedException)
                {
                    Console.WriteLine("Caught Interrupt Exception");
                }
                finally
                {
                    // empty block
                }
                Console.WriteLine("Child thread exiting");

            }


            public void runTest()
            {

                Thread child = new Thread(() =>
                {
                    childThread();
                });

                child.Start();

                // wait for child thread to block on Sleep

                Thread.Sleep(1000);

                Console.WriteLine("Interrupting Child Thread");
                // now interrupt the child thread
                child.Interrupt();

                // wait for child thread to finish
                child.Join();

                Console.WriteLine("Main thread exiting");
            }
        }
    }
}
