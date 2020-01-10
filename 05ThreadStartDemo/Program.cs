using System;
using System.Threading;

namespace _05ThreadStartDemo
{
    class Demonstration
    {
        static void Main()
        {
            new UsingThreadStart().runTest();
            new UsingParameterisedThreadStart().runTest();
        }
    }

    public class UsingThreadStart
    {

        static void sayHi()
        {
            Console.WriteLine("Hi from static method");
        }


        void sayHello()
        {
            Console.WriteLine("Hello from instance method");
        }

        public void runTest()
        {
            ThreadStart threadStart = new ThreadStart(sayHi);
            Thread thread = new Thread(threadStart);
            thread.Start();
            thread.Join();

            threadStart = new ThreadStart(new UsingThreadStart().sayHello);
            thread = new Thread(threadStart);
            thread.Start();
            thread.Join();
        }
    }

    public class UsingParameterisedThreadStart
    {

        static void sayHi(Object obj)
        {
            String name = (String)obj;
            Console.WriteLine("Hi " + name + " from static method");
        }


        void sayHello(Object obj)
        {
            String name = (String)obj;
            Console.WriteLine("Hello " + name + " from instance method");
        }

        public void runTest()
        {
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(sayHi);
            Thread thread = new Thread(threadStart);
            thread.Start("Fahim");
            thread.Join();

            threadStart = new ParameterizedThreadStart(new UsingParameterisedThreadStart().sayHello);
            thread = new Thread(threadStart);
            thread.Start("Fahim");
            thread.Join();
        }
    }
}
