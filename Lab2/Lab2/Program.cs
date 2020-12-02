using System;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("ЛАБОРАТОРНАЯ РАБОТА №2: ЗАДАЧА АЛГЕБРАИЧЕСКОГО ИНТЕРПОЛИРОВАНИЯ\n" +
                              "Вариант №1\n" +
                              "Функция: ln(1+x)\n" +
                              "Начальные данные: a = 0; b = 1; x = 0.35; m = 15; n = 7");
            var chosen = -1;
            while (chosen != 0)
            {
                Console.WriteLine("Какие данные использовать?\n"+
                                  "1 - Указанные начальные данные\n" +
                                  "2 - Ввести свои данные\n" +
                                  "0 - Выйти из программы");
                chosen = Convert.ToInt32(Console.ReadLine());
                if (chosen == 1)
                {
                    Worker worker = new Worker(0, 1, 15);
                    worker.generateAndPrintTable();
                    worker.work(0.35, 7);
                    Console.WriteLine("\n");
                }
                if (chosen == 2)
                {
                    Console.WriteLine("Введите a");
                    bool repeat = true;
                    var a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите b");
                    var b = Convert.ToInt32(Console.ReadLine());
                    while (a >= b)
                    {
                        Console.WriteLine("Значение a должно быть больше значения b, введите другие a и b");
                        Console.WriteLine("Введите a");
                        a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите b");
                        b = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Введите m");
                    var m = Convert.ToInt32(Console.ReadLine());
                    Worker worker = new Worker(a, b, m);
                    worker.generateAndPrintTable();
                    Console.WriteLine('\n');

                    while (repeat)
                    {
                        Console.WriteLine("Введите n, где n <= " + m);
                        var n = Convert.ToInt32(Console.ReadLine());
                        while (n > m)
                        {
                            Console.WriteLine("Ошибка! n не может быть больше m! Введите другую n");
                            n = Convert.ToInt32(Console.ReadLine());
                        }

                        Console.WriteLine("Введите x");
                        var x = Convert.ToDouble(Console.ReadLine());
                        worker.work(x, n);
                        Console.WriteLine("\n");
                        Console.WriteLine("Введите 0, чтобы выйти из программы, введите любой другой знак, чтобы выбрать другие n и x");
                        var isRepeats = Console.ReadLine();
                        if (isRepeats == "0") repeat = false;
                    }
                }
            }
        }
    }
}