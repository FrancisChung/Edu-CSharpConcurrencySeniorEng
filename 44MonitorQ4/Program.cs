using System;
using System.Threading;

namespace _44MonitorQ4
{
    class Program
    {
        static void Main(string[] args)
        {
            new QuizQuestion().run();
            Console.ReadKey();
        }
    }

    public class QuizQuestion
    {
        private Object obj = false; //boxed Boolean will haunt you!

        public void printMessage()
        {

            Monitor.Enter(obj);
            obj = true;
            Thread.Sleep(3000);
            Monitor.Exit(obj);
            Console.WriteLine("All is good");
        }

        public void run()
        {

            Thread t1 = new Thread(new ThreadStart(printMessage));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(printMessage));
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }
}
