using System;
using System.Threading;

namespace _37PrimeFinderMonitor
{ 

    class Demonstration
    {
        static void Main()
        {
            new PrimeFinderMonitor().run();
        }
    }

    public class PrimeFinderMonitor
    {
        bool found = false;
        int prime;
        volatile bool shutdown = false;
        Object lockObj = new Object();

        private bool isPrime(int i)
        {
            if (i == 2 || i == 3) return true;

            int div = 2;

            while (div <= i / 2)
            {
                if (i % div == 0) return false;
                div++;
            }

            return true;
        }


        public void printer()
        {
            while (!shutdown)
            {
                Monitor.Enter(lockObj);

                while (!found)
                {
                    Monitor.Wait(lockObj);
                }

                Console.WriteLine("Prime found to be = " + prime);

                found = false;
                Monitor.Pulse(lockObj);
                Monitor.Exit(lockObj);

            }
        }


        public void finder()
        {
            prime = 2;
            while (!shutdown)
            {

                if (isPrime(prime))
                {
                    Monitor.Enter(lockObj);

                    found = true;
                    Monitor.Pulse(lockObj);

                    while (found)
                    {
                        Monitor.Wait(lockObj);
                    }

                    Monitor.Exit(lockObj);
                }

                prime++;

            }
        }


        public void run()
        {

            Thread primeFinderThread = new Thread(new ThreadStart(finder));
            Thread printerThread = new Thread(new ThreadStart(printer));

            primeFinderThread.Start();
            printerThread.Start();

            Thread.Sleep(1000);

            shutdown = true;

            printerThread.Join();
            primeFinderThread.Join();

        }
    }
}
