using System;

namespace Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

            foreach(var v in array) Console.WriteLine(v);
            Console.WriteLine("");

            System.Threading.Tasks.Parallel.ForEach<int>(array, (x => Console.WriteLine(x)));
            Console.WriteLine("");

            Console.WriteLine("Type anything to exit.");
            Console.Read();
        }
    }
}
