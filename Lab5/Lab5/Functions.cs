using System;

namespace Lab5
{
    public static class Functions
    {
        public static double F_First(double x)
            => Math.Sin(x);

        public static double F_Second(double x)
            => Math.Cos(x);

        public static double P_First(double x)
            => Math.Pow(x, 1 / 4.0);

        public static double P_Second(double x)
            => (1.0 / Math.Sqrt(1 - Math.Pow(x, 2)));

        public static double Func_First(double x)
            => F_First(x) * P_First(x);
    }
}