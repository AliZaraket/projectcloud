using System.Collections.Generic;

namespace AysncAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> mylist = new List<int>() { 1, 2, 3 };
            foreach(int i in mylist) {
            Console.WriteLine(i);
            }
            mylist.Add(1);
        }
    }
}