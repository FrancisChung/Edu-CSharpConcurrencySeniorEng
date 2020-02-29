using System;
using System.Threading;

namespace _59PollingLoopPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            new PollingLoopPattern().mainThread();
            Console.ReadKey();
        }
    }
    /**
     * However, marking a field volatile is not enough to prevent it from being hoisted,
     * which is another optimization technique that reads the value of the variable keepGoing only at the start of the method
     * and never again because keepGoing doesn't get modified within the same anonymous method.
     *
     */
    class PollingLoopPattern
    {

        volatile bool keepGoing = true;
        void childThread()
        {

            while (keepGoing)
            {
                // Do something important
            }

        }


        public void mainThread()
        {
            Thread child = new Thread(() =>
            {
                childThread();
            });

            child.Start();

            Thread.Sleep(1000);

            keepGoing = false;

            child.Join();
        }
    }
}
