using System;
using System.Threading;

namespace _58MemoryBarrier2
{
    class Program
    {
        static void Main(string[] args)
        {
            new ReorderExample().RunTest();
        }
    }

    public class ReorderExample
    {
        int myVal;
        bool done;

        void threadB()
        {
            // Barrier#1
            Thread.MemoryBarrier();
            if (done)
            {
                // Barrier#2
                Thread.MemoryBarrier();
                Console.WriteLine(myVal);
            }
        }


        void threadA()
        {
            myVal = 7;
            // Barrier#3
            Thread.MemoryBarrier();

            done = true;
            // Barrier#4
            Thread.MemoryBarrier();
        }

        public void RunTest()
        {
            Thread thrA = new Thread(() => threadA());
            Thread thrB = new Thread(() => threadB());
            thrA.Start();
            thrB.Start();

            thrA.Join();
            thrB.Join();

            Console.ReadKey();
        }
    }
}
