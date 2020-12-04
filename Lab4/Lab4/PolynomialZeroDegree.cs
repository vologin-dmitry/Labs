namespace Lab4
{
    public class PolynomialZeroDegree : Function
    {
        public double countFunction(double data) => -3.5;

        public double countIntegral(double data) => data * -3.5;

        public double countDerivative(double data) => 0;
        
        public double countSecondDerivative(double data) => 0;

        public double countFourthDerivative(double data) => 0;
    }
}