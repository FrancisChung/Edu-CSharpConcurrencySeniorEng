using System;
using System.Threading;

namespace _39ValueTypeMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            int valueType = 5;

            Monitor.Enter(valueType);
            Monitor.Pulse(valueType);
            Monitor.Exit(valueType);

            Console.WriteLine("This should not work");
            Console.ReadLine();
        }
    }
}
