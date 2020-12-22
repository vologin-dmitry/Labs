using System;

namespace Lab6
{
    public static class Function
    {
        public static double CountFunction(double x) => 2 * Math.Pow(Math.E, -x) + x - 1;
        public static double DifferentialEquatation(double x) => -CountFunction(x) + x;
    }
}