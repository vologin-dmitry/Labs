using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Worker
    {
        private List<KeyValuePair<double, double>> list;
        private double b, a;
        private int m;

        public Worker(double a, double b, int m)
        {
            this.a = a;
            this.b = b;
            this.m = m;
            list = new List<KeyValuePair<double, double>>();
        }

        private void FillTable()
        {
            double x, y;
            for (int i = 0; i < m + 1; ++i)
            {
                x = (double) a + ((b - a) / m) * i;
                y = Function.CountFunction(x);
                list.Add(new KeyValuePair<double, double>(x,y));
            }
        }

        private void SwapTable()
        {
            var temp = new List<KeyValuePair<double, double>>();
            foreach (var it in list)
            {
                temp.Add(new KeyValuePair<double, double>(it.Value, it.Key));
            }

            list = temp;
        }
        private void SortTable(double x)
        {
            list.Sort(delegate(KeyValuePair<double, double> first, KeyValuePair<double, double> second)
            {
                if (Math.Abs(first.Key - x) - Math.Abs(second.Key - x) < 0)
                {
                    return -1;
                }

                if (Math.Abs(first.Key - x) - Math.Abs(second.Key - x) > 0) 
                {
                    return 1;
                }

                return 0;
            });
        }

        private double Lagrange(double x, int n)
        {
            double result = 0;
            double temp;
            for(int i = 0; i < n; ++i)
            {
                temp = 1;
                for (int j = 0; j < n; ++j)
                {
                    if (i != j)
                    {
                        temp = temp * (x - (list[j]).Key) / (list[i].Key - list[j].Key);
                    }
                }
                result += (double)temp * (list[i].Value);
            }
            return result;
        }

        public void PrintTable()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            int i = 0;
            foreach (var it in list)
            {
                Console.WriteLine(i + ": " + it.Key + " | " + it.Value);
                ++i;
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        public void GenerateAndPrintTable()
        {
            FillTable();
            Console.WriteLine("Неотсортированная таблица:");
            PrintTable();
        }

        public void FirstMethod(double F, int n)
        {
            Console.WriteLine("Первый метод");
            Console.WriteLine("Отсортированная таблица для функции f^-1 относительно точки " + F + ":");
            SwapTable();
            SortTable(F);
            PrintTable();
            var result = Lagrange(F, n);
            Console.WriteLine("Значение x:" + result);
            Console.WriteLine("Погрешность: " + Math.Abs(F - Function.CountFunction(result)));
        }
        
        public void SecondMethod(double F, int n, double eps)
        {
            FillTable();
            Console.WriteLine("Второй метод");
            ModifiedSort(F);
            PrintTable();
            var result = BisectionMethod(a, b, eps, F);
            Console.WriteLine("Значение x: " + result);
            Console.WriteLine("Погрешность: " + Math.Abs(Function.CountFunction(result) - F));
        }
        private void ModifiedSort(double F)
        {
            double previousX = 0;
            double c = 0;
            foreach (var couple in list)
            {
                var currentX = couple.Key;
                var y = couple.Value;
                if (F >= y)
            		previousX = currentX;
            	else
            	{
            		c = (previousX + currentX) / 2;
            		break;
            	}
            }
            SortTable(c);
        }
        
        private double BisectionMethod(double a, double b, double eps, double F)
        {
            int steps = 0;
            do
            {
                double c = (a + b) / 2;
                if ((Function.CountFunction(a) - F) * (Function.CountFunction(c) - F) <= 0)
                    b = c;
                else a = c;
                ++steps;
            } while (b - a > 2 * eps);
            double X = (a + b) / 2;

            return X;
        }
    }
}