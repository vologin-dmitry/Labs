namespace Lab4
{
    public class PolynomialZeroDegree : IFunction
    {
        public double CountFunction(double data) => -3.5;

        public double CountIntegral(double data) => data * -3.5;

        public double CountDerivative(double data) => 0;
        
        public double CountSecondDerivative(double data) => 0;

        public double CountFourthDerivative(double data) => 0;
    }
}