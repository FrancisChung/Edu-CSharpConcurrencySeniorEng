using System;
using System.Threading;
using System.Threading.Tasks;

namespace _54TaskFactoryDemo
{


    class Demonstration
    {
        static void Main()
        {
            Task task = Task.Factory.StartNew((object obj) => {

                Console.WriteLine("Hello " + obj);

            }, "Reader");
            task.Wait();
        }
    }
}
