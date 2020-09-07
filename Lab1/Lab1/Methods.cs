using System;

namespace Lab1
{
    public static class Methods
    {
        public static void BisectionMethod(double a, double b, double eps)
        {
            int steps = 0;
            do
            {
                double c = (a + b) / 2;
                if (Function.Calculate(a) * Function.Calculate(c) <= 0)
                    b = c;
                else a = c;
                ++steps;
            } while (b - a > 2 * eps);
            double X = (a + b) / 2;
            double delta = (b - a) / 2;

            Console.WriteLine("Корень: " + X);
            Console.WriteLine("Дельта " + delta);
            Console.WriteLine("Абсолютная величина невязки " + Math.Abs(Function.Calculate(X) - 0));
            Console.WriteLine("Количество шагов: " + steps + '\n');
        }

        public static void NewtonMethod(double a, double b, double eps)
        {
            int steps = 0;
            double x1 = a;
            double x2 = b;
            double xs = (a + b) / 2;
            int p = 1;
            
            x2 = xs;
            do
            {
                x1 = x2;
                if (Function.CalculateDerivative(x1) == 0)
                {
                    p += 2;
                    x2 = xs;
                }
                else  
                    x2 = x1 - p * Function.Calculate(x1) / Function.CalculateDerivative(x1);
                ++steps;
            } while (Math.Abs(x2 - x1) > eps);

            double X = (x1 - Function.Calculate(x1) / Function.CalculateDerivative(x1));
            double delta = Math.Abs(x2 - x1) / 2;
            
            Console.WriteLine("Корень: " + X);
            Console.WriteLine("Начальное приближение: " + xs);
            Console.WriteLine("Дельта " + delta);
            Console.WriteLine("Абсолютная величина невязки " + Math.Abs(Function.Calculate(X) - 0));
            Console.WriteLine("Количество шагов: " + steps + '\n');
        }

        public static void NewtonModifiedMethod(double a, double b, double eps)
        {
            int steps = 0;
            double x1 = a;
            double x2 = b;
            double xs = (a + b) / 2;

            x2 = xs;
            double firstDerivative = Function.CalculateDerivative(x2);
            do
            {
                x1 = x2;
                x2 =  x2 - Function.Calculate(x2) / firstDerivative;
                ++steps;
            } while (Math.Abs(x2 - x1) > eps);

            double X = (x1 - Function.Calculate(x1) / firstDerivative);
            double delta = Math.Abs(x2 - x1) / 2;
            
            Console.WriteLine("Корень: " + X);
            Console.WriteLine("Начальное приближение: " + xs);
            Console.WriteLine("Дельта " + delta);
            Console.WriteLine("Абсолютная величина невязки " + Math.Abs(Function.Calculate(X) - 0));
            Console.WriteLine("Количество шагов: " + steps + '\n');
        }

        public static void SecantMethod(double a, double b, double eps)
        {
            int steps = 0;
            double x1 = a;
            double x2 = b;
            double x3 = 0;
            double xs = x2 - Function.Calculate(x2) * (x2 - x1) /
                (Function.Calculate(x2) - Function.Calculate(x1));

            do
            {
                x3 = x2 - (Function.Calculate(x2) * (x2 - x1) /
                                    (Function.Calculate(x2) - Function.Calculate(x1)));
                x1 = x2;
                x2 = x3;
                ++steps;
            } while (Math.Abs(x2 - x1) > eps);

            double X = x2 - Function.Calculate(x2) * (x2 - x1) /
                                (Function.Calculate(x2) - Function.Calculate(x1));
            double delta = Math.Abs(x2 - x1) / 2;
            Console.WriteLine("Корень: " + X);
            Console.WriteLine("Начальное приближение: " + xs);
            Console.WriteLine("Дельта " + delta);
            Console.WriteLine("Абсолютная величина невязки " + Math.Abs(Function.Calculate(X) - 0));
            Console.WriteLine("Количество шагов: " + steps + '\n');
        }
    }
}