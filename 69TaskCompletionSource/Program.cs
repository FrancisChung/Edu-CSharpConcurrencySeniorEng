using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace _69TaskCompletionSource
{
    class Program
    {
        static void Main(string[] args)
        {
            new Demonstration().Start();
        }
    }

    class Demonstration
    {
        public void Start()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Task waitTask = WaitFor3Secs();

            waitTask.Wait();
            sw.Stop();

            Console.WriteLine("Main program exiting after " + sw.ElapsedMilliseconds / 1000.0 + " seconds");
        }

        static async Task Wrapper()
        {
            await WaitFor3Secs();
        }

        static Task WaitFor3Secs()
        {
            TaskCompletionSource<String> tcs = new TaskCompletionSource<string>();
            Task task = tcs.Task;

            // Do your async stuff. For demo, we create a
            // thread to sleep
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(3000);
                tcs.SetResult(null);    //Comment this line and execution will execute forever?

            });
            thread.Start();

            return task;
        }
    }
}
