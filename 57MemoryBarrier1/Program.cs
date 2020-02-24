using System;
using System.Threading;

namespace _56MemoryBarrier1
{
    class Program
    {
        static void Main(string[] args)
        {
            new PossibleReorderingExample().runTest();
            Console.WriteLine("Terminated");
            Console.ReadKey();
        }
    }

    public class PossibleReorderingExample
    {
        bool keepGoing = true;

        public void work()
        {
            while (keepGoing)
            {
                Console.WriteLine("Doing something important");
                Thread.MemoryBarrier();
            }
        }


        public void runTest()
        {

            Thread childThread = new Thread(() =>
            {
                work();
            });
            childThread.Start();


            // let child thread run for a second
            Thread.Sleep(1000);

            // update the flag
            keepGoing = false;
            Thread.MemoryBarrier();

            // wait for child thread to terminate
            childThread.Join();

        }
    }
}
