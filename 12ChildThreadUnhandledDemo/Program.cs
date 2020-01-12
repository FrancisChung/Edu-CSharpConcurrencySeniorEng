using System;
using System.Threading;
namespace _12ChildThreadUnhandledDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ChildThreadUnhandled.runTest();
            //Console.ReadKey();
        }

        public class ChildThreadUnhandled
        {
            public static void runTest()
            {

                Thread thread = new Thread(() =>
                {

                    // Throw an unhandled exception
                    throw new Exception("");

                });


                thread.Start();
                thread.Join();

                Console.WriteLine("Alive");

            }
        }
    }
}
