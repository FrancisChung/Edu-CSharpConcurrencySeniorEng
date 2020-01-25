using System;
using System.Threading;
namespace _40ValueTypeMonitorWorks
{
    class Program
    {
        static void Main(string[] args)
        {
            int valueType = 5;
            Object valueTypeBoxed = valueType;

            Monitor.Enter(valueTypeBoxed);

            // Singal the monitor
            Monitor.Pulse(valueTypeBoxed);

            Monitor.Exit(valueTypeBoxed);

            Console.WriteLine("This works but not good practice");
            Console.ReadKey();
        }
    }
}
