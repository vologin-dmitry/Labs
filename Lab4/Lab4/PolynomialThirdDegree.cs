using System;

namespace Lab4
{
    public class PolynomialThirdDegree : IFunction
    {
        public double CountFunction(double data) => 12 * Math.Pow(data, 3) + 3 * data * data - 14 * data + 23;

        public double CountIntegral(double data) =>
            3 * Math.Pow(data, 4) + Math.Pow(data, 3) - 7 * data * data + 23 * data;

        public double CountDerivative(double data) => 36 * data * data + 6 * data - 14;

        public double CountSecondDerivative(double data) => 72 * data + 6;

        public double CountFourthDerivative(double data) => 0;
    }
}