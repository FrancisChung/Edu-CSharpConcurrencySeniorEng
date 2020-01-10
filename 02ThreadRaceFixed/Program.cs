using System;
using System.Threading;

namespace _02ThreadRaceFixed
{

    public class RaceCondition
    {
        private int randInt;
        Random random = new Random();
        Mutex mutex = new Mutex();

        void printer()
        {
            long i = 100000000;
            while (i != 0)
            {
                mutex.WaitOne();
                if (randInt % 5 == 0)
                {
                    if (randInt % 5 != 0)
                        Console.WriteLine(randInt); //With Mutex, this is impossible condition
                }
                mutex.ReleaseMutex();
                i--;
            }
        }

        void modifier()
        {
            long i = 100000000;
            while (i != 0)
            {
                mutex.WaitOne();
                randInt = random.Next(1000);
                mutex.ReleaseMutex();
                i--;
            }
        }

        public void RunTest()
        {
            Thread printerThread = new Thread(new ThreadStart(printer));
            Thread modifierThread = new Thread(new ThreadStart(modifier));

            printerThread.Start();
            modifierThread.Start();

            printerThread.Join();
            modifierThread.Join();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new RaceCondition().RunTest();
        }
    }

}