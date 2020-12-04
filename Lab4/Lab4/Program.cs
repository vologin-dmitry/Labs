using System;
using System.Net;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №4");
            var func = new PolynomialFirstDegree();
            
            var worker = new Worker(0, 1, 500, func);
            worker.Integral();
            Console.WriteLine('\n');
            
            var worker2 = new Worker(0,1,200, new PolynomialZeroDegree());
            worker.Integral();
            Console.WriteLine('\n');
            
            var worker3 = new Worker(0,1,200, new Exponent());
            worker3.IntegralAndTheoreticalPrecision();
        }
    }
}