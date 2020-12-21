using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3._2
{
    public class Worker
    {
        private double h;
        private int m;
        private double a;
        private List<double> xValues = new List<double>();
        private List<double> yValues = new List<double>();
        private List<double> firstDerivatives = new List<double>();
        private List<double> firstDerivativesPrecision = new List<double>();
        private List<double> secondDerivatives = new List<double>();
        private List<double> secondDerivativesPrecision = new List<double>();

        public Worker(double a, double h, int m)
        {
            this.a = a;
            this.h = h;
            this.m = m;
            for (int i = 0; i <= m; ++i)
            {
                xValues.Add(a + i * h);
                yValues.Add(Function.Count(a + i * h));
            }
        }

        private double FirstDerivative(double x)
        {
            return (Function.Count(x + h) - Function.Count(x - h)) / (2 * h);
        }

        private double FirstDerivativeBegin(double x)
        {
            return (-3 * Function.Count(x) + 4 * Function.Count(x + h) - Function.Count(x + 2 * h)) / (2 * h);
        }

        private double FirstDerivativeEnd(double x)
        {
            return (3 * Function.Count(x) - 4 * Function.Count(x - h) + Function.Count(x - 2 * h)) / (2 * h);
        }

        private double SecondDerivative(double x)
        {
            return (Function.Count(x + h) - 2 * Function.Count(x) + Function.Count(x - h)) / (h * h);
        }

        private void FillLists()
        {
            var temp = FirstDerivativeBegin(xValues[0]);
            firstDerivatives.Add(temp);
            firstDerivativesPrecision.Add(Math.Abs(temp - Function.CountDerivative(xValues[0])));

            secondDerivatives.Add(0);
            secondDerivativesPrecision.Add(0);

            for (int i = 1; i < xValues.Count - 1; ++i)
            {
                temp = FirstDerivative(xValues[i]);
                firstDerivatives.Add(temp);
                firstDerivativesPrecision.Add(Math.Abs(temp - Function.CountDerivative(xValues[i])));

                secondDerivatives.Add(SecondDerivative(xValues[i]));
                secondDerivativesPrecision.Add(Math.Abs(SecondDerivative(xValues[i]) -
                                                        Function.CountSecondDerivative(xValues[i])));
            }

            temp = FirstDerivativeEnd(xValues[xValues.Count - 1]);
            firstDerivatives.Add(temp);
            firstDerivativesPrecision.Add(Math.Abs(temp - Function.CountDerivative(xValues[xValues.Count - 1])));

            secondDerivatives.Add(0);
            secondDerivativesPrecision.Add(0);
        }

        public void PrintTable()
        {
            FillLists();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \t x \t \t f(x) \t \t f'(x) ч.д.    |f'(x) - f'(x) ч.д.|    f\"(x) ч.д     |f\"(x) - f\" ч.д.|");
            Console.ResetColor();
            for (var i = 0; i < xValues.Count; ++i)
            {
                Console.Write("{0:F14} | ", xValues[i]);
                Console.Write("{0:F14} | ", yValues[i]);
                Console.Write("{0:F14} | ", firstDerivatives[i]);
                Console.Write("{0:F14} | ", firstDerivativesPrecision[i]);
                Console.Write("{0:F14} | ", secondDerivatives[i]);
                Console.Write("{0:F14}\n", secondDerivativesPrecision[i]);
            }
        }
}
}