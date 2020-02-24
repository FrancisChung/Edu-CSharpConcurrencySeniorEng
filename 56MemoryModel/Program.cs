using System;
using System.Threading;

namespace _56MemoryModel
{
    public class PossibleReorderingExample
    {


        bool keepGoing = true;


        public static void Main()
        {
            new PossibleReorderingExample().runTest();
        }

        public void work()
        {
            while (keepGoing)
            {
                Console.WriteLine("Doing something important");
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

            // wait for child thread to terminate
            childThread.Join();
            Console.Write("Child Thread terminated");
            Console.ReadKey();

        }
    }
}
