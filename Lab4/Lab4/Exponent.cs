using System;
using System.ComponentModel;

namespace Lab4
{
    public class Exponent : IFunction
    {
        public double CountFunction(double data) => Math.Pow(Math.E, data);

        public double CountIntegral(double data) => Math.Pow(Math.E, data);

        public double CountDerivative(double data) => Math.Pow(Math.E, data);

        public double CountSecondDerivative(double data) => Math.Pow(Math.E, data);

        public double CountFourthDerivative(double data) => Math.Pow(Math.E, data);
    }
}