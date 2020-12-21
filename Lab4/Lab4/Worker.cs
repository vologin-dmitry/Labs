using System;

namespace Lab4
{
    public class Worker
    {
        private double A;
        private double B;
        private double m;
        private double h;
        private double y;
        private double p;
        private double w;
        private double integralForCheck;
        private IFunction function;

        public Worker(double A, double B, int m, IFunction function)
        {
            var h = (B - A) / m;
            this.m = m;
            this.A = A;
            this.B = B;
            this.h = h;
            this.function = function;
            for (var i = 1; i < m; ++i)
            {
                y += function.CountFunction(A + h * i);
            }

            for (var i = 0; i <= m - 1; ++i)
            {
                p += function.CountFunction(A + h * i + h / 2);
            }
            integralForCheck = function.CountIntegral(B) - function.CountIntegral(A);
            w = (function.CountFunction(A) + function.CountFunction(B));
        }

        public void LeftRectangles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Метод левых прямоугольников");
            Console.ResetColor();
            var integral = h * (function.CountFunction(A) + y);
            Console.WriteLine("Интеграл равен " + integral);
            Console.WriteLine("Погрешность: " + Math.Abs(integral - integralForCheck));
        }
        
        public void RightRectangles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Метод правых прямоугольников");
            Console.ResetColor();
            var integral = h * (y + function.CountFunction(B));
            Console.WriteLine("Интеграл равен " + integral);
            Console.WriteLine("Погрешность: " + Math.Abs(integral - integralForCheck));
        }

        public void MiddleRectangles()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Метод средних прямоугольников");
            Console.ResetColor();
            var integral = h * p;
            Console.WriteLine("Интеграл равен " + integral);
            Console.WriteLine("Погрешность: " + Math.Abs(integral - integralForCheck));
        }
        
        public void Trapezes()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Метод трапеций");
            Console.ResetColor();
            var integral = h * (w / 2 + y);
            Console.WriteLine("Интеграл равен " + integral);
            Console.WriteLine("Погрешность: " + Math.Abs(integral - integralForCheck));
        }

        public void Simpson()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Метод Симпсона");
            Console.ResetColor();
            double integral = h * (p * 2.0 / 3 + w * 1.0 / 6 + y * 1.0 / 3);
            Console.WriteLine("Интеграл равен " + integral);
            Console.WriteLine("Погрешность: " + Math.Abs(integral - integralForCheck));
        }

        public void Integral()
        {
            LeftRectangles();
            Console.WriteLine();
            RightRectangles();
            Console.WriteLine();
            MiddleRectangles();
            Console.WriteLine();
            Trapezes();
            Console.WriteLine();
            Simpson();
            Console.WriteLine();
        }

        public double TheoreticalPrecision(double c, int d, double max)
        {
            return c * (B - A) * Math.Pow((B - A) / m, d + 1) * max;
        }

        public void IntegralAndTheoreticalPrecision()
        {
            LeftRectangles();
            var temp = TheoreticalPrecision(0.5, 0, function.CountDerivative(B));
            Console.WriteLine("Теоретическая погрешность: " + temp);
            Console.WriteLine();
            
            RightRectangles();
            Console.WriteLine("Теоретическая погрешность: " + temp);
            Console.WriteLine();
            
            MiddleRectangles();
            Console.WriteLine("Теоретическая погрешность: " + TheoreticalPrecision(1.0 / 24, 1, function.CountSecondDerivative(B)));
            Console.WriteLine();
            
            Trapezes();
            Console.WriteLine("Теоретическая погрешность: " + TheoreticalPrecision(1.0 / 12, 1, function.CountSecondDerivative(B)));
            Console.WriteLine();
            
            Simpson();
            Console.WriteLine("Теоретическая погрешность: " + TheoreticalPrecision(1.0 / 2880, 3, function.CountFourthDerivative(B)));
        }
        
    }
}