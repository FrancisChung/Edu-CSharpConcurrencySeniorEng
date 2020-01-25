using System;
using System.Threading;

namespace _43MonitorQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            new QuizQuestion().run();
            Console.ReadKey();
        }

        public class QuizQuestion
        {
            private readonly Object obj = new Object();

            public void enterTwice()
            {

                Monitor.Enter(obj);
                Monitor.Enter(obj);
                Console.WriteLine("Hello");
                Monitor.Exit(obj);
            }

            public void enterOnce()
            {
                Monitor.Enter(obj);
                Console.WriteLine("World");
                Monitor.Exit(obj);
            }

            public void run()
            {
                Thread thread1 = new Thread(new ThreadStart(enterTwice));
                thread1.Start();
                thread1.Join();
                Console.WriteLine("Thread 1 join");



                Thread thread2 = new Thread(new ThreadStart(enterOnce));
                thread2.Start();
                Console.WriteLine("Thread 2 started");

                thread2.Join();
                Console.WriteLine("Thread 2 join");

            }
        }
    }
}
