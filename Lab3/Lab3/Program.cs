using System;

namespace Lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "Лабораторная работа №3. Задача обратного интерполирования");
            Console.WriteLine(
                "Функция: Ln(1 + x)");
            Console.WriteLine("Вариант 2");
            Console.WriteLine("Проверочные данные: A = 0;\nB = 1;\nm = 10;\neps = 10^(-8)");

            var repeat = true;
            Console.WriteLine("Введите A");
            var a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите B");
            var b = Convert.ToDouble(Console.ReadLine());
            while (a >= b)
            {
                Console.WriteLine("Значение a должно быть больше значения b, введите другие a и b");
                Console.WriteLine("Введите A");
                a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите B");
                b = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("Введите m");
            var m = Convert.ToInt32(Console.ReadLine());
            Worker worker = new Worker(a, b, m);
            worker.GenerateAndPrintTable();
            Console.WriteLine('\n');

            while (repeat)
            {
                Console.WriteLine("Введите n, где n <= " + m);
                var n = Convert.ToInt32(Console.ReadLine());
                while (n > m)
                {
                    Console.WriteLine("Ошибка! n не может быть больше m! Введите другое n");
                    n = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("Введите F");
                var F = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите эпсилон");
                var eps = Convert.ToDouble(Console.ReadLine());
                worker.FirstMethod(F, n);
                Console.WriteLine();
                new Worker(a, b, m).SecondMethod(F, n, eps);
                Console.WriteLine("\n");
                Console.WriteLine(
                    "Введите 0, чтобы выйти из программы, введите любой другой знак, чтобы выбрать другие n, эпсилон и F");
                var isRepeats = Console.ReadLine();
                if (isRepeats == "0") repeat = false;
            }
        }
    }
}