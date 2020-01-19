using System;
using System.Threading;

namespace _30InterlockedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new InterlockedAddExample().runTest();
            Console.ReadKey();
        }
    }

    public class InterlockedAddExample
    {
        long j = 0;


        public void runTest()
        {

            Thread[] threads = new Thread[10];

            // Create 10 threads
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(() =>
                {

                    for (long k = 0; k < 100000; k++)
                    {
                        //j++;
                        Interlocked.Increment(ref j);
                    }
                });
            }

            // Run all 10 threads
            for (int i = 0; i < 10; i++)
            {
                threads[i].Start();
            }

            // Wait for all the threads to finish
            for (int i = 0; i < 10; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine("Value of j = " + j);
        }
    }

}
