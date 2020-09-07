using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа №1\n");
            Console.WriteLine("Начальные данные: ");
            Console.WriteLine("Функция: 2^(-x) - sin(x), Отрезок: [-5, 10], Эпсилон: 10^(-6)");
            Console.WriteLine("Введите начало отрезка");

            double A = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите конец отрезка");
            double B = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите количество отрезков");
            int N = Convert.ToInt32(Console.ReadLine());

            double eps = 0.000006;
            var sections = Separation.Separate(A, B, N);

            Console.WriteLine("Бисекция:");
            foreach (var section in sections)
            {
                Methods.BisectionMethod(section.Key, section.Value, eps);
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("Метод Ньютона:");
            foreach (var section in sections)
            {
                Methods.NewtonMethod(section.Key, section.Value, eps);
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("Модифицированный метод Ньютона:");
            foreach (var section in sections)
            {
                Methods.NewtonModifiedMethod(section.Key, section.Value, eps);
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine("Метод секущих");
            foreach (var section in sections)
            {
                Methods.SecantMethod(section.Key, section.Value, eps);
            }
        }
    }
}