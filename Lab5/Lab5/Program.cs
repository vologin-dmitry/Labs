using System;
using static System.Console;

namespace Lab5
{
    class Program
    {
public static void Main(string[] args)
        {
            WriteLine("Лабораторная работа номер 5");
            WriteLine("Приближённое вычисление интегралов при помощи квадратурных формул Наивысшей Алгебраической Степени Точности");
            WriteLine("Вариант 2");
            WriteLine("Входные данные :");
            WriteLine(
                "А = 0;\n" +
                "B = 1;\n" +
                "f1 = sin(x);\n" +
                "p1 = x^(1/2);\n" +
                "f2 = cos(x);\n" +
                "p2 = 1/sqrt(1-x^2);\n" +
                "Число промежутков деления (m) = 100;\n" +
                "Число узлов для КФ Меллера (N) = 6;\n");
            
            var repeat = true;
            while (repeat)
            {
                WriteLine("Введите A");
                var A = Convert.ToInt32(ReadLine());
                WriteLine("Введите B");
                var B = Convert.ToInt32(ReadLine());
                WriteLine("Введите число промежутков деления (m)");
                var M = Convert.ToInt32(ReadLine());
                WriteLine("Введите число узлов для КФ Меллера (N)");
                var N = Convert.ToInt32(ReadLine());
                var worker = new Worker(A, B, M);

                worker.Gauss();
                WriteLine();
                worker.GausLike();
                WriteLine();
                worker.Mehler(N);
                
                WriteLine("\nВведите 1, чтобы продолжить или 0, чтобы выйти");
                repeat = (1 == Convert.ToInt32(ReadLine()));
            }
        }
    }
}