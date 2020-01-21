using System;
using System.Threading;

namespace _36MonitorWaitException
{
    class Program
    {
        static void Main()
        {
            Object obj = new object();

            // Monitor.Enter(obj);

            Monitor.Wait(obj);  //Can't be called from Unsynchronised block of code

            // Monitor.Exit(obj);

        }
    }
}
