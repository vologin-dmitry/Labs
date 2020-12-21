using System;

namespace Lab3._2
{
    public static class Function
    {
        public static double Count(double x)
        {
            return Math.Pow(Math.E, 4.5 * x);
        }
        
        public static double CountDerivative(double x)
        {
            return 4.5 * Math.Pow(Math.E, 4.5 * x);
        }
        
        public static double CountSecondDerivative(double x)
        {
            return 20.25 * Math.Pow(Math.E, 4.5 * x);
        }
    }
}