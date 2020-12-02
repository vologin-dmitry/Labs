using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lab2
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

        private void fillTable()
        {
            double x, y;
            for (int i = 0; i < m + 1; ++i)
            {
                x = (double) a + ((b - a) / m) * i;
                y = Function.countFunction(x);
                list.Add(new KeyValuePair<double, double>(x,y));
            }
        }

        private void sortTable(double x)
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

        private void lagrange(double x, int n)
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
                result += (double)temp * Function.countFunction(list[i].Key);
            }
            Console.WriteLine("Значение интерполяционного многочлена, найденное при помощи представления в форме Лагранжа " + result);
            Console.WriteLine("Значение абсолютной фактической погрешности: " + (Math.Abs(Function.countFunction(x) - result)));
        }

        private void newton(double x, int n)
        {
            double result = list[0].Value, F, den;
            int i, j, k;
            for (i = 1; i <= n; i++)
            {
                F = 0;
                for (j = 0; j <= i; j++)
                {
                    den = 1;
                    for (k = 0; k <= i; k++)
                    {
                        if (k != j)
                            den *= (list[j].Key - list[k].Key);
                    }
                    F += list[j].Value / den;
                }
                for (k = 0; k < i; k++)
                    F *= (x - list[k].Key);
                result += F;
            }
            Console.WriteLine("Значение интерполяционного многочлена, найденное при помощи представления в форме Ньютона " + result);
            Console.WriteLine("Значение абсолютной фактической погрешности: " + (Math.Abs(Function.countFunction(x) - result)));
        }

        public void printTable()
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            int i = 0;
            foreach (var it in list)
            {
                Console.WriteLine("x" + i + ": " + it.Key + " | " + it.Value);
                ++i;
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }

        public void generateAndPrintTable()
        {
            fillTable();
            Console.WriteLine("Неотсортированная таблица:");
            printTable();
        }

        public void work(double x, int n)
        {
            Console.WriteLine("Отсортированная таблица:");
            sortTable(x);
            printTable();
            lagrange(x, n);
            newton(x, n);
        }

    }
}