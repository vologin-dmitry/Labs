using System;
using System.ComponentModel;

namespace Lab4
{
    public class Exponent : Function
    {
        public double countFunction(double data) => Math.Pow(Math.E, data);

        public double countIntegral(double data) => Math.Pow(Math.E, data);

        public double countDerivative(double data) => Math.Pow(Math.E, data);

        public double countSecondDerivative(double data) => Math.Pow(Math.E, data);

        public double countFourthDerivative(double data) => Math.Pow(Math.E, data);
    }
}