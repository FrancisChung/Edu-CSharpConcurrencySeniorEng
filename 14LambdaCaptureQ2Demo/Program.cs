using System;
using System.Threading;

namespace _14LambdaCaptureQ2Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new LambdaCapture().runTest();
            Console.ReadKey();
        }

        public class LambdaCapture
        {

            public void runTest()
            {

                Thread[] threads = new Thread[5];
                int i = 0;
                for (i = 0; i < 5; i++)
                {
                    threads[i] = new Thread(() =>
                    {
                        Console.WriteLine(i);
                    });
                }

                i = 9;

                for (int k = 0; k < 5; k++)
                    threads[k].Start();

                for (int k = 0; k < 5; k++)
                    threads[k].Join();

            }
        }
    }
}
