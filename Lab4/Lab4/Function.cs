namespace Lab4
{
    public interface IFunction
    {
        double CountFunction(double data);
        double CountIntegral(double data);
        double CountDerivative(double data);
        double CountSecondDerivative(double data);
        double CountFourthDerivative(double data);
    }
}