using System;
using System.Collections.Generic;

namespace Lab6
{
    public class Worker
    {
        private double x0 = 0;
        private double y0 = 1;
        private double h;
        private int N;
        private double[] coeff = {1, -1, 2, -2, 2};
        private double[] x_s;
        private double[] y_s;
        private double[] taylor;
        private double[] euler;
        private double[] eulerOne;
        private double[] eulerTwo;
        private double[] runge;
        private double[] adams;
        private double[] xHelper;

    public Worker(double h, int N)
        {
            this.h = h;
            this.N = N;
            
            x_s = new double[N + 3];
            xHelper = new double[N + 1];
            y_s = new double[N + 3];
            taylor = new double[N + 3];
            euler = new double[N + 1];
            eulerOne = new double[N + 1];
            eulerTwo = new double[N + 1];
            runge = new double[N + 1];
            adams = new double[N + 3];
            
            for (var i = -2; i <= N; ++i)
            {
                x_s[i + 2] = h * i;
                y_s[i + 2] = Function.CountFunction(h * i);
            }

            for (var i = 0; i <= N; ++i)
            {
                xHelper[i] = x_s[i + 2];
            }

            euler[0] = y0;
            eulerOne[0] = y0;
            eulerTwo[0] = y0;
            runge[0] = y0;
            FillTaylor();
            FillEuler();
            FillEulerOne();
            FillEulerTwo();
            FillRunge();
            FillAdams();
        }

        void FillTaylor()
        {
            for (var i = 0; i < x_s.Length; ++i)
            {
                taylor[i] = Taylor_Function(x_s[i]);
            }
        }

        void FillEuler()
        {
            for (int i = 1; i < euler.Length; i++)
            {
                euler[i] = euler[i - 1] + h * Function.DifferentialEquatation(xHelper[i - 1], euler[i - 1]);
            }
        }
        
        void FillEulerOne()
        {
            for (int i = 1; i < euler.Length; i++)
            {
                double temp = eulerOne[i - 1] + (h / 2) * Function.DifferentialEquatation(xHelper[i - 1], eulerOne[i - 1]);
                eulerOne[i] = eulerOne[i - 1] + h * Function.DifferentialEquatation(xHelper[i - 1] + h / 2, temp);
            }
        }

        void FillEulerTwo() 
        {
            for (int i = 1; i <= N; i++)
            {
                double f = Function.DifferentialEquatation(xHelper[i - 1], eulerTwo[i - 1]);
                double Y_k = eulerTwo[i - 1] + h * f;
                eulerTwo[i] = eulerTwo[i - 1] + (h / 2) * (f + Function.DifferentialEquatation(xHelper[i], Y_k));
            }
        }

        void FillRunge()
        {
            for (var i = 1; i <= N; ++i)
            {
                double x = xHelper[i - 1];
                double y = runge[i - 1];
                double k1 = h * Function.DifferentialEquatation(x, y);
                double k2 = h * Function.DifferentialEquatation(x + h / 2, y + k1 / 2);
                double k3 = h * Function.DifferentialEquatation(x + h / 2, y + k2 / 2);
                double k4 = h * Function.DifferentialEquatation(x + h, y + k3);

                runge[i] = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
            }
        }

        void FillAdams()
        {
            List<double> begin = new List<double>();
            List<double> dq = new List<double>();
            List<double> dqSecond = new List<double>();
            List<double> dqThird = new List<double>();
            List<double> dqFourth = new List<double>();

            for (int i = 0; i < 5; i++)
            {
                begin.Add(h * Function.DifferentialEquatation(x_s[i], y_s[i]));
                adams[i] = taylor[i];
            }
            for (int i = 0; i < 4; i++)
            {
                dq.Add(begin[i + 1] - begin[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                dqSecond.Add(dq[i + 1] - dq[i]);
            }
            for (int i = 0; i < 2; i++)
            {
                dqThird.Add(dqSecond[i + 1] - dqSecond[i]);
            }
            for (int i = 0; i < 1; i++) 
            {
                dqFourth.Add(dqThird[i + 1] - dqThird[i]);
            }

            for (int i = 5; i <= N + 2; i++) 
            {
                adams[i] = (adams[i - 1] + begin[i - 1] + dq[i - 2] / 2.0 + 5 * dqSecond[i - 3] / 12.0 
                        + 3 * dqThird[i - 4] / 8.0 + 251 * dqFourth[i - 5] / 720.0);
                begin.Add(h * Function.DifferentialEquatation(x_s[i], y_s[i]));
                dq.Add(begin[i] - begin[i - 1]);
                dqSecond.Add(dq[i - 1] - dq[i - 2]);
                dqThird.Add(dqSecond[i - 2] - dqSecond[i - 3]);
                dqFourth.Add(dqThird[i - 3] - dqThird[i - 4]);
            }
        }


        double Taylor_Function(double x)
        {
            int power = 0;
            double toReturn = 0;
            for (int i = 0; i < 5; i++)
            {
                toReturn += coeff[i] / Factorial(power) * Math.Pow(x, power);
                ++power;
            }
            return toReturn;
        }
        int Factorial(int j)
        {
            if (j == 0 || j == 1)
            {
                return 1;
            }
            int result = 1;
            for (int i = 2; i <= j; i++)
            {
                result *= i;
            }
            return result;
        }

        public void PrintExactTable()
        {
            PrintTable(x_s, 0, y_s, 0);
        }
        
        public void PrintTaylorTable()
        {
            PrintTable(x_s, 0, taylor, 0);
            for (int i = 0; i < x_s.Length; ++i)
            {
                Console.WriteLine("Погрешность в точке " + (x0 + h * (i - 2)) + " = " + Math.Abs(y_s[i] - taylor[i]));
            }
        }
        
        public void PrintAdamsTable()
        {
            PrintTable(x_s, 5, adams, 5);
        }
        
        public void PrintRungeTable()
        {
            PrintTable(x_s, 3, runge, 1);
        }
        
        public void PrintEulerTable()
        {
            PrintTable(x_s, 3, euler, 1);
        }
        
        public void PrintEulerOneTable()
        {
            PrintTable(x_s, 3, eulerOne, 1);
        }
        
        public void PrintEulerTwoTable()
        {
            PrintTable(x_s, 3, eulerTwo, 1);
        }
        
        
        void PrintTable(double[] x, int xBegin, double[] y, int yBegin)
        {
            for (int i = 0; i < y.Length - yBegin; i++)
            {
                Console.Write("| " + x[i + xBegin] + " | ");
                Console.Write(y[i + yBegin] + " |");
                Console.WriteLine();
            }
        }

        private void Last(double[] y, string name)
        {
            Console.WriteLine("Погрешность последнего члена для метода" + ": " + name + " " +
                              Math.Abs(y_s[y_s.Length - 1] - y[y.Length - 1]));
        }

        public void LastAdams()
        {
            Last(adams, "Адамса");
        }
        
        public void LastRunge()
        {
            Last(runge, "Рунге-Кутта");
        }
        
        public void LastEuler()
        {
            Last(euler, "Эйлера");
        }

        public void LastEulerI()
        {
            Last(eulerOne, "Эйлера I");
        }
        
        public void LastEulerII()
        {
            Last(eulerTwo, "Эйлера II");
        }
        
        public void LastTaylor()
        {
            Last(taylor, "Тейлора");
        }
    }
}