using System;
using System.Threading;

namespace _15ThreadStartX2Q3Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().RunTest();
            Console.ReadKey();
        }

        void greet()
        {
            Console.WriteLine("Hi");
        }

        public void RunTest()
        {
            Thread thread = new Thread(() =>
            {
                greet();
            });

            thread.Start();
            thread.Join();

            thread.Start();
            thread.Join();
        }
    }
}
