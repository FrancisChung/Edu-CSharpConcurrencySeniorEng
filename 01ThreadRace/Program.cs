using System;
using System.Threading;

namespace _01ThreadRace
{

    public class RaceCondition
    {
        private int randInt;
        Random random = new Random();


        void printer()
        {
            long i = 100000000;
            while (i != 0)
            {
                if (randInt % 5 == 0)
                {
                    if (randInt % 5 != 0)
                        Console.WriteLine(randInt);
                }

                i--;
            }
        }

        void modifier()
        {
            long i = 100000000;
            while (i != 0)
            {
                randInt = random.Next(1000);
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
