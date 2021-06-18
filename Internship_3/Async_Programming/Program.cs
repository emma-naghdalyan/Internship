using System;
using System.Threading;

namespace Async_Programming
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);

        static void Main(string[] args)
        {
            Thread currentTrade = Thread.CurrentThread;
            AppDomain ad = Thread.GetDomain();
            // Obtain the context under which the
            // current thread is operating.
            //Context ctx = Thread.CurrentContext;


            //Console.WriteLine("***** Synch Delegate Review *****");
            //// Print out the ID of the executing thread.
            //Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
            //// Invoke Add() in a synchronous manner.
            //BinaryOp b = new BinaryOp(Add);
            //// Could also write b.Invoke(10, 10);
            //int answer = b(10, 10);
            //// These lines will not execute until
            //// the Add() method has completed.
            //Console.WriteLine("Doing more work in Main()!");
            //Console.WriteLine("10 + 10 is {0}.", answer);
            //Console.ReadLine();


            Console.WriteLine("***** Async Delegate Invocation *****");
            // Print out the ID of the executing thread.
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Invoke Add() on a secondary thread.
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 10, null, null);
            // Do other work on primary thread...
            Console.WriteLine("Doing more work in Main()!");
            // Obtain the result of the Add()
            // method when ready.
            int answer = b.EndInvoke(ar);
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            // Print out the ID of the executing thread.
            Console.WriteLine("Add() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            // Pause to simulate a lengthy operation.
            Thread.Sleep(5000);
            return x + y;
        }

    }
}
