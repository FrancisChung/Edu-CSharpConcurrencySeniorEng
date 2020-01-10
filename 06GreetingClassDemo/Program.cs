using System;

namespace _06GreetingClassDemo
{
    using System;
    using System.Threading;

    class Demonstration
    {
        static void Main()
        {
            GreetingClass gc = new GreetingClass("Fahim");
            ThreadStart ts = new ThreadStart(gc.sayHello);
            Thread thread = new Thread(ts);
            thread.Start();
            thread.Join();
        }
    }

    public class GreetingClass
    {

        private String name;

        public GreetingClass(String name)
        {
            this.name = name;
        }

        public void sayHello()
        {
            Console.WriteLine("Hello " + name + " from instance method");
        }
    }
}
