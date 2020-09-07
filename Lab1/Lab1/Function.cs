using System;

namespace Lab1
{
    public static class Function
    {
        public static double Calculate(double x) => Math.Pow(2, -x) - Math.Sin(x);
        public static double CalculateDerivative(double x) => -Math.Log(2) * Math.Pow(2, -x) - Math.Cos(x);
    }
}