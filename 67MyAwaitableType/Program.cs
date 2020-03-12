using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace _67MyAwaitableType    
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var awaitableType = new MyAwaitableType(3000);
            await awaitableType;
            Console.WriteLine("End");
            //Console.ReadKey();
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

            public void GetResult()
            {
                Console.WriteLine("GetResult");
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
                    Console.WriteLine("OnCompleted");
                });
                
                thread.Start();
            }
        }
    }
}
