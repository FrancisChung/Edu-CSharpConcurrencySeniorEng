using System;
using System.Threading;

namespace _42MonitorQ2
{
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

        public static void Main()
        {
            Thread thread = new Thread(new ThreadStart(new QuizQuestion().enterTwice));
            thread.Start();
            thread.Join();
        }
    }
}
