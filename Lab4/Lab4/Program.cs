using System;
using System.Net;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "Лабораторная работа №4. Приближённое вычисление интеграла по составным квадратурным формулам\n" +
                "Варинат 2");
            Console.WriteLine("Функции:");
            Console.WriteLine("f(x) = -3.5");
            Console.WriteLine("f(x) = 2.5x - 4");
            Console.WriteLine("f(x) = 12 * x^3 + 3 * x^2 - 14 * x + 23");
            Console.WriteLine("f(x) = e^x" + '\n');

            var repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите A");
                var A = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите B");
                var B = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите число промежутков деления отрезка (m)");
                var m = Convert.ToInt32(Console.ReadLine());
                var h = (B - A) / m;

                Console.WriteLine("A = " + A);
                Console.WriteLine("B = " + B);
                Console.WriteLine("m = " + m);
                Console.WriteLine("h = " + h);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("f(x) = -3.5");
                Console.ResetColor();
                (new Worker(A, B, m, new PolynomialZeroDegree())).Integral();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("f(x) = 2.5x - 4");
                Console.ResetColor();
                (new Worker(A, B, m, new PolynomialFirstDegree())).Integral();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("f(x) = 12 * x^3 + 3 * x^2 - 14 * x + 23");
                Console.ResetColor();
                (new Worker(A, B, m, new PolynomialThirdDegree())).Integral();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("f(x) = e^x");
                Console.ResetColor();
                (new Worker(A, B, m, new Exponent())).IntegralAndTheoreticalPrecision();
                Console.WriteLine();
                
                Console.WriteLine("Введите 1, чтобы ввести другие A, B и m");
                repeat = (1 == Convert.ToInt32(Console.ReadLine()));
            }
        }
    }
}
