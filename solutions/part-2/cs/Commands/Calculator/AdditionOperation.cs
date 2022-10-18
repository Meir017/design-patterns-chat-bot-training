namespace ChatBot.Commands.Calculator;

public class AdditionOperation : ICalculatorOperation
{
    public int Execute(int a, int b) => a + b;
}