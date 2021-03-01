using System;
using static System.Console;
using static Lab5.Functions;

namespace Lab5
{
    public class Worker
    {
        private double h;
        private double moment0, moment1, moment2, moment3;
        private double a1, a2;
        private double x1, x2;
        private double A1, A2;
        private double A, B;
        private int m;
        private double p, y, w;
        private double[] pForMoments = new double[4];

        public Worker(double A, double B, int m)
        {
            var h = (B - A) / m;
            this.m = m;
            this.A = A;
            this.B = B;
            this.h = h;
            for (var i = 1; i < m; ++i)
            {
                y += Func_First(A + h * i);
            }

            for (var i = 0; i <= m - 1; ++i)
            {
                var temp = A + h * i + h / 2;
                p += Func_First(temp);
                for (var j = 0; j < 4; j++)
                {
                    pForMoments[j] += MomentsHelper(temp, j);
                }
            }

            w = (Func_First(A) + Func_First(B));
        }

        private double MomentsHelper(double x, int number)
        {
            if (number == 0)
            {
                return P_First(x);
            }

            if (number == 1)
            {
                return P_First(x) * x;
            }

            if (number == 2)
            {
                return P_First(x) * x * x;
            }

            return P_First(x) * x * x * x;
        }

        private double CountMomentWithMiddleRectangles(int number)
            => h * pForMoments[number];

        public void GausLike()
        {
            moment0 = CountMomentWithMiddleRectangles(0);
            moment1 = CountMomentWithMiddleRectangles(1);
            moment2 = CountMomentWithMiddleRectangles(2);
            moment3 = CountMomentWithMiddleRectangles(3);
            a1 = (moment0 * moment3 - moment2 * moment1) / (moment1 * moment1 - moment0 * moment2);
            a2 = (moment2 * moment2 - moment3 * moment1) / (moment1 * moment1 - moment0 * moment2);
            WriteLine("Нулевой момент = " + moment0);
            WriteLine("Первый момент = " + moment1);
            WriteLine("Второй момент = " + moment2);
            WriteLine("Третий момент = " + moment3);
            var discriminant = Math.Sqrt(a1 * a1 - 4 * a2);
            x1 = (-a1 + discriminant) / 2.0;
            x2 = (-a1 - discriminant) / 2.0;
            A1 = 1 / (x1 - x2) * (moment1 - x2 * moment0);
            A2 = 1 / (x2 - x1) * (moment1 - x1 * moment0);
            WriteLine("Ортогональный многочлен: x^2 - (" + (x1 + x2) + ")*x + " + x1 * x2);
            WriteLine("Узел x1: " + x1);
            WriteLine("Узел x2: " + x2);
            WriteLine("Коэффициент A1: " + A1);
            WriteLine("Коэффициент A2: " + A2);

            ForegroundColor = ConsoleColor.Yellow;
            Write("[проверка] ");
            ResetColor();
            WriteLine(!IsEqual(x1, x2) ? "Узлы x1 и x2 различны" : "Узлы x1 и x2 совпадают");
            ForegroundColor = ConsoleColor.Yellow;
            Write("[проверка] ");
            ResetColor();
            WriteLine(
                IsEqual(A1 + A2, moment0) ? "A1 + A2 равно нулевому моменту" : "А1 + А2 не равно нулевому моменту");
            ForegroundColor = ConsoleColor.Yellow;
            Write("[проверка] ");
            ResetColor();
            WriteLine(A1 >= 0 && A2 >= 0 ? "A1 и А2 больше или равны нулю" : "А1 или А2 меньше нуля");

            var gaussLike = A1 * F_First(x1) + A2 * F_First(x2);
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Интеграл по формуле типа Гаусса: " + gaussLike);
            ResetColor();
            WriteLine("Погрешность с формулой Cимпсона: " + Math.Abs(gaussLike - Simpson()));
            WriteLine("Погрешность при А=0 В=1: " + Math.Abs(gaussLike - 0.4065383082972653));
        }
        
        private double Simpson()
            => h * (p * 2.0 / 3 + w * 1.0 / 6 + y * 1.0 / 3);
        
        public void Gauss()
        {
            double integral = 0;
            double Zk = A;
            double t1 = -1.0 / Math.Sqrt(3);
            double t2 = 1.0 / Math.Sqrt(3);
            for (int i = 0; i < m; i++)
            {
                x1 = (h / 2) * t1 + Zk + h / 2;
                x2 = (h / 2) * t2 + Zk + h / 2;

                integral += (h / 2) * (Func_First(x1) + Func_First(x2));

                Zk += h;
            }
            WriteLine("Значение интеграла по Cимпсону: " + Simpson());
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Значение интеграла по формуле Гауса: " + integral);
            ResetColor();
            WriteLine("Погрешность с формулой Cимпсона: " + (Math.Abs(integral - Simpson())));
            WriteLine("Погрешность при А=0 В=1: " + (Math.Abs(integral - 0.4065383082972653)));
        }

        public void Mehler(int N)
        {
            var constant = Math.PI / N;
            double result = 0;
            for (int i = 1; i <= N; i++)
            {
                double x = Math.Cos(((double)(2.0 * i - 1.0) /( 2.0 * N)) * Math.PI);
                WriteLine("Узел " + i + " = " + x);
                result += F_Second(x);
                WriteLine("Коэфициент " + i + " = " + constant * F_Second(x));
            }

            result *= constant;
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Значение интеграла вычисленное с помощью КФ Меллера = " +result);
            ResetColor();
            WriteLine("Погрешность = " + Math.Abs(result - 1.201969715061311 * 2));
        }

        private bool IsEqual(double x1, double x2) => (x1 - x2) < 0.000000001;
        
        public double Simpson2()
        {
            double result_1 = 0.0;
            double result_2 = 0.0;
            double result_3 = 0.0;
            double h_2 = h / 2.0;
            double x_k;
            for (int i = 0; i <= 2 * m; i++) 
            { 
                x_k = A + i * h_2; 
                if (i == 0 || i == (2 * m)) 
                { 
                    result_1 += Func_First(x_k); 
                } 
                if ((i != 0) && (i != 2 * m) && (i % 2 == 1)) 
                { 
                    result_2 += 4 * Func_First(x_k); 
                } 
                if ((i != 0) && (i != 2 * m) && (i % 2 == 0)) 
                { 
                    result_3 += 2 * Func_First(x_k); 
                } 
            } 
            return (result_1 + result_2 + result_3) * h_2 / 3.0;
        }
        
        double CountMomentWithMiddleRectangles2(int k)
        {
            double result = 0.0;
            for (int i = 1; i <= m; i++)
            {
                result += h * MomentsHelper(A + h / 2.0 + (i - 1) * h, k);
            }
            return result;
        }
        
    }
}