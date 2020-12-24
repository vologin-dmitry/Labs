using System;
using static System.Console;

namespace Lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WriteLine("Лабораторная работа номер 6");
            WriteLine("Численное решение Задачи Коши для обыкновенного дифференциального уравнения первого порядка");
            WriteLine("Входные данные :");
            WriteLine(
                "Дифференциальное уравнение : y'(x) = -y + x ;\nШаг между точками : h=0,1 ;\nКоличество точек : N=10 ;\nРешение задачи Коши y(0)=0");
            
            var repeat = true;
            while (repeat)
            {
                WriteLine("Введите количество точек (N)");
                var N = Convert.ToInt32(ReadLine());
                WriteLine("Введите h");
                var h = Convert.ToDouble(ReadLine());
                var worker = new Worker(h, N);
                
                WriteLine("Таблица точного значения функции в равностоящих точках :");
                worker.PrintExactTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная методом разложения в ряд тейлора и погрешность для каждой точки :");
                worker.PrintTaylorTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная экстраполяционным методом Адамса 4-ого порядка");
                worker.PrintAdamsTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная методом Рунге-Кутта 4-ого порядка");
                worker.PrintRungeTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная методом Эйлера");
                worker.PrintEulerTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная методом Эйлера I");
                worker.PrintEulerOneTable();
                WriteLine();
                WriteLine("Таблица приближенных значений полученная методом Эйлера II");
                worker.PrintEulerTwoTable();
                WriteLine();
                
                worker.LastTaylor();
                worker.LastAdams();
                worker.LastRunge();
                worker.LastEuler();
                worker.LastEulerI();
                worker.LastEulerII();
                repeat = (1 == Convert.ToInt32(ReadLine()));
            }
        }
    }
}