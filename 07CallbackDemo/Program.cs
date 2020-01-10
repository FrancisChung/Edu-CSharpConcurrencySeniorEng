using System;
using System.Threading;

namespace _07CallbackDemo
{
    class Demonstration
    {
        static void Main()
        {
            RetrieveResults retrieveResults = new RetrieveResults(10, (double res) =>
            {
                Console.WriteLine("Result = " + res);
            });

            ThreadStart ts = new ThreadStart(retrieveResults.square);
            Thread thread = new Thread(ts);

            thread.Start();
            thread.Join();
        }
    }

    // Delegate that defines the signature of the callback method.
    public delegate void ResultCallback(double result);

    public class RetrieveResults
    {
        private int x;
        ResultCallback callback;

        public RetrieveResults(int x, ResultCallback callback)
        {
            this.x = x;
            this.callback = callback;
        }


        public void square()
        {
            double result = x * x;

            if (callback != null)
                callback(result);
        }
    }
}
