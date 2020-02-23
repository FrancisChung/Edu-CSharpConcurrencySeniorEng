using System;
using System.Threading.Tasks;

namespace _52TaskExample
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

            Task task = new Task(() => {
                Console.WriteLine("Hello World");
            });

            task.Start();
            task.Wait();
            Console.ReadKey();

        }
    }
}
