using Microsoft.Ajax.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Async_Programming
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);
        private static bool isDone = false;
        static void Main(string[] args)
        {
            Thread currentTrade = Thread.CurrentThread;
            AppDomain ad = Thread.GetDomain();

            // Context ctx = Thread.CurrentContext;


            //Console.WriteLine("***** Synch Delegate Review *****");

            //Console.WriteLine("Main() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);

            //BinaryOp b = new BinaryOp(Add);
            //int answer = b(10, 10);
            //Console.WriteLine("Doing more work in Main()!");
            //Console.WriteLine("10 + 10 is {0}.", answer);
            //Console.ReadLine();


            /* Console.WriteLine("***** Async Delegate Invocation *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            IAsyncResult ar = b.BeginInvoke(10, 52, null, null);
            Console.WriteLine("Doing more work in Main()!");

            // int answer = b.EndInvoke(ar);


            while (!ar.IsCompleted)
            {
                Console.WriteLine("Doing more work in Main()!");
                Thread.Sleep(1000);
            }
            // Now we know the Add() method is complete.
            int answer = b.EndInvoke(ar);            
            
            Console.WriteLine("10 + 10 is {0}.", answer);
            Console.ReadLine(); */


            Console.WriteLine("***** AsyncCallbackDelegate Example *****");
            Console.WriteLine("Main() invoked on thread {0}.",
            Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);
            Task task = Task.Run(() => b(10, 10));

            task.Wait();
            Console.WriteLine("Working....");
            Thread.Sleep(1000);
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
        //static void AddComplete(IAsyncResult iar)
        //{
        //    Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
        //    Console.WriteLine("Your addition is complete");
        //    isDone = true;
        //}
        //static void AddComplete(IAsyncResult iar)
        //{
        //    Console.WriteLine("AddComplete() invoked on thread {0}.", Thread.CurrentThread.ManagedThreadId);
        //    Console.WriteLine("Your addition is complete");
        //    // Now get the result.
        //    AsyncResult ar = (AsyncResult)iar;
        //    BinaryOp b = (BinaryOp)ar.AsyncDelegate;
        //    Console.WriteLine("10 + 10 is {0}.", b.EndInvoke(iar));
        //    isDone = true;
        //}
    }
}
