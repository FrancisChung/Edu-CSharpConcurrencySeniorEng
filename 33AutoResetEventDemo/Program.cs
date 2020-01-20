using System;
using System.Threading;

namespace _33AutoResetEventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new AutoResetEventDemo().RunTest();
            Console.ReadKey();
        }

        public class AutoResetEventDemo
        {
            AutoResetEvent are1 = new AutoResetEvent(false);
            AutoResetEvent are2 = new AutoResetEvent(false);

            void Work(int num)
            {
                are1.WaitOne();
                Console.WriteLine($"Num : {num}");
                Thread.Sleep(400);

                are2.Set();
            }

            public void RunTest()
            {
                Thread t1 = new Thread(() => Work(5));
                t1.IsBackground = true;

                Thread t2 = new Thread(() => Work(10));
                t2.IsBackground = true;

                Console.WriteLine("Threads Starting");

                t1.Start();
                t2.Start();

                Thread.Sleep(1000);

                are1.Set();
                Console.WriteLine("ar1 Set");

                Thread.Sleep(400);
                are2.WaitOne();
                Console.WriteLine("are2 WaitOne");

                Console.WriteLine("Exiting");
            }
        }
    }
}
