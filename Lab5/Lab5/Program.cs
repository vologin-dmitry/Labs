using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker(0, 1, 100000);
            worker.Gauss();
            Console.WriteLine();
            worker.GausLike();
            worker.Mehler(6);
        }
    }
}