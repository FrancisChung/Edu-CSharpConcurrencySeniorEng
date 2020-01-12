using System;
using System.Threading;

namespace _13ThreadAbortUnhandledNet472Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ChildThreadUnhandled.runTest();
            Console.ReadKey();
        }

        public class ChildThreadUnhandled
        {
            public static void runTest()
            {

                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Thread Aborting");
                    Thread.CurrentThread.Abort();

                });


                thread.Start();
                thread.Join();

                Console.WriteLine("Aborted but Alive");

            }
        }
    }
}
