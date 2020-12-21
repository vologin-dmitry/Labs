using System;

namespace Lab6
{
    public class Worker
    {
        private double x0;
        private double h;
        private int N;
        public Worker(double x0, double h, int N)
        {
            this.x0 = x0;
            this.h = h;
            this.N = N;
        }

        public void CorrectResult()
        {
            for (int i = -2; i < N; ++i)
            {
                Console.WriteLine(Function.CountFunction(x0 + h * i));
            }
        }

        public double Tailor(double x)
        {
            var toReturn = 0;
            for (int i = 0; i < 5; ++i)
            {
                toReturn += 1;
            }

            return toReturn;
        }

        private double GetNthDerivative(double x)
        {
            
        }
    }
}