using System;
using System.Runtime.Remoting.Messaging;

namespace Lab3._2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "Лабораторная работа №3. Нахождение производных таблично-заданной функции по формулам численного дифференцирования");
            Console.WriteLine("Функция: e^(4.5)");
            var repeat = true;
            while (repeat)
            {
                Console.WriteLine("Введите m");
                var m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите A");
                var a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите h");
                var h = Convert.ToDouble(Console.ReadLine());
                while (h <= 0)
                {
                    Console.WriteLine("h должен быть болше машинного нуля! Введите другой h");
                    h = Convert.ToDouble(Console.ReadLine());
                }
                new Worker(a, h, m).PrintTable();
                Console.WriteLine("Введите q, чтобы выйти из программы");
                repeat = (Console.ReadLine() != "q");
            }
        }
    }
}