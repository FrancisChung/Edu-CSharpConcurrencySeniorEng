using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _68AsyncSleepMyAwaitableType
{
    class Program
    {

        class Demonstration
        {
            static async Task<String> SuperSleep()
            {

                MyAwaitableType t1 = new MyAwaitableType(1000);
                MyAwaitableType t2 = new MyAwaitableType(1000);
                MyAwaitableType t3 = new MyAwaitableType(1000);

                await t1;
                await t2;
                return await t3;
            }

            static async Task Main()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                Task<String> superSleepTask = SuperSleep();
                Console.WriteLine(superSleepTask.Result);
                sw.Stop();
                Console.WriteLine("Main thread id " + Thread.CurrentThread.ManagedThreadId + " program execution took = " + (sw.ElapsedMilliseconds / 1000.0) + " seconds");
            }
        }

        public class MyAwaitableType : INotifyCompletion
        {
            private int _sleepFor = 0;
            private bool _completed;

            public MyAwaitableType(int sleepFor)
            {
                this._sleepFor = sleepFor;
            }

            public MyAwaitableType GetAwaiter()
            {
                Console.WriteLine("GetAwaiter()");
                return this;
            }

            public string GetResult()
            {
                Console.WriteLine("GetResult");
                return $@"Hello Thread {Thread.CurrentThread.ManagedThreadId}";
            }

            public bool IsCompleted
            {
                get
                {
                    Console.WriteLine($"IsCompleted returns {_completed}");
                    return _completed;
                }
            }

            public void OnCompleted(Action continuation)
            {
                var thread = new Thread(() =>
                {
                    Thread.Sleep(_sleepFor);
                    _completed = true;
                    continuation();
                    Console.WriteLine($"OnCompleted Thread:{Thread.CurrentThread.ManagedThreadId}");
                });

                thread.Start();
            }
        }
    }
}
