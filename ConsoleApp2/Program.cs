using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main asynchronously on thread {Thread.CurrentThread.ManagedThreadId}...");

            //WaitAsync();
            var s1 = WaitAsync().Result; // Calling WaitAsync method and blocking the Main method until it completes
            Console.WriteLine(s1.ToString()); // Printing the result returned by WaitAsync method
            Console.WriteLine("Result returned");
            Task.Delay(3000).Wait(); // Simulating a delay for 3 seconds
            Console.WriteLine($"Main asynchronously on thread {Thread.CurrentThread.ManagedThreadId}...");
        }

        private static async Task<string> WaitAsync()
        {
            Console.WriteLine($"asynchronously on thread {Thread.CurrentThread.ManagedThreadId}...");
            Console.WriteLine("Print before delay");
            await Task.Delay(2000); // Asynchronous delay of 10 seconds
            Console.WriteLine("Print after delay");
            Console.WriteLine($"asynchronously on thread {Thread.CurrentThread.ManagedThreadId}...");
            return "I am done"; // Returning a string when the asynchronous operation completes
        }
    }
}


