using System;
using System.Collections.Generic;

namespace Lab1
{
    public static class Separation
    {
        public static List<KeyValuePair<double, double>> Separate(double A, double B, int N)
        {
            var sections = new List<KeyValuePair<double, double>>(); 
            double H = Math.Abs(A - B) / N;
            double X1 = A;
            double X2 = X1 + H;
            double Y1 = Function.Calculate(X1);
            int counter = 0;
            while (X2 <= B)
            {
                double Y2 = Function.Calculate(X2);
                if (Y1 * Y2 <= 0)
                {
                    ++counter;
                    sections.Add(new KeyValuePair<double, double>(X1, X2));
                }
                X1 = X2;
                X2 = X2 + H;
                Y1 = Y2;
            }
            Console.WriteLine("Количество найденных корней:" + counter);
            return sections;
        }
    }
}