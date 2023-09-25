

public class CalcService: InCalcService
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Substract(int a, int b)
    {
        return a - b;
    }
    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        return a / b;

        if(b == 0){
            throw new ArgumentException("Division by zero is not allowed.");
        }
        return a / b;
    }
}