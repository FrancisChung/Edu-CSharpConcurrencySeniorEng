using System;
using System.Threading;

namespace _41MonitorQ1
{
    public class QuizQuestion
    {

        private readonly Object obj = new Object();

        static void Main(string[] args)
        {
            new QuizQuestion().run();
            Console.WriteLine("run() Done");
            Console.ReadKey();
        }

        void MonitorExit()
        {
            Thread.Sleep(500);
            Monitor.Exit(obj);
        }


        void MonitorEnter()
        {
            Monitor.Enter(obj);
            Thread.Sleep(500);
        }

        public void run()
        {

            Thread t1 = new Thread(new ThreadStart(MonitorEnter));
            Thread t2 = new Thread(new ThreadStart(MonitorExit));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Hello");
            Monitor.Enter(obj);
            Console.WriteLine("World");
            Monitor.Exit(obj);
        }
    }
}
