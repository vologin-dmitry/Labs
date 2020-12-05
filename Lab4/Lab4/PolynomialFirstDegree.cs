namespace Lab4
{
    public class PolynomialFirstDegree : IFunction
    {
        public double CountFunction(double data) => 2.5 * data - 4;

        public double CountIntegral(double data) => 1.25 * data * data - 4 * data;

        public double CountDerivative(double data) => 2.5;
        
        public double CountSecondDerivative(double data) => 0;

        public double CountFourthDerivative(double data) => 0;
    }
}