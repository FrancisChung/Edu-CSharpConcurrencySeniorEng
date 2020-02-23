using System;
using System.Threading;
using System.Threading.Tasks;

namespace _53TaskResultsDemo
{
    class Demonstration
    {
        static void Main()
        {
            new TaskExample().runTest();
        }
    }

    public class TaskExample
    {
        public void runTest()
        {

            Task<String> task = new Task<String>((Object obj) =>
            {
                String name = (String)obj;
                Console.WriteLine("Hello " + name);
                Thread.Sleep(5000);
                return "Task Completed Successfully";
            }, "Reader", TaskCreationOptions.None);
            task.Start();
            Console.WriteLine(task.Result);
        }
    }
}
