namespace Lab4
{
    public class PolynomialFirstDegree : Function
    {
        public double countFunction(double data) => 2.5 * data - 4;

        public double countIntegral(double data) => 1.25 * data * data - 4 * data;

        public double countDerivative(double data) => 2.5;
        
        public double countSecondDerivative(double data) => 0;

        public double countFourthDerivative(double data) => 0;
    }
}