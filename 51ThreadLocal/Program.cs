using System;
using System.Threading;

namespace _51ThreadLocal
{
    class Demonstration
    {
        static void Main()
        {
            new ThreadLocalExample().runTest();
            Console.ReadKey();
        }
    }

    public class ThreadLocalExample
    {

        ThreadLocal<int> threadValue = new ThreadLocal<int>();
        Barrier barrier = new Barrier(5);

        void work(object obj)
        {
            int i = (int)obj;
            threadValue.Value = i * i;
            barrier.SignalAndWait();

            Console.WriteLine("Thread with id " + Thread.CurrentThread.ManagedThreadId + " computed square = " + threadValue.Value);

        }

        public void runTest()
        {

            Thread[] threads = new Thread[5];

            for (int i = 0; i < 5; i++)
                threads[i] = new Thread(new ParameterizedThreadStart(this.work));

            for (int i = 0; i < 5; i++)
                threads[i].Start(i + 1);

            for (int i = 0; i < 5; i++)
                threads[i].Join();

        }
    }
}
