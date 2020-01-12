using System;
using System.Threading;

namespace _11ThreadAbortResetAbortDemo
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
                catch (ThreadAbortException)
                {
                    Console.WriteLine("Caught Abort Exception");
                    Thread.ResetAbort();
                    Console.WriteLine("Reset Abort");
                }
                finally
                {
                    // empty block
                }
                Console.WriteLine("Child thread exiting");

            }


            public void runTest()
            {
                try
                {
                    Thread child = new Thread(() =>
                    {
                        childThread();
                    });

                    child.Start();

                    // wait for child thread to block on Sleep

                    Thread.Sleep(1000);

                    Console.WriteLine("Aborting Child Thread");
                    // now interrupt the child thread
                    child.Abort();

                    // wait for child thread to finish
                    child.Join();

                    Console.WriteLine("Main thread exiting");
                }
                catch (PlatformNotSupportedException ex)
                {
                    Console.WriteLine("Looks like Thread Abort is not supported in .NET Core");
                }
            }
        }
    }
}
