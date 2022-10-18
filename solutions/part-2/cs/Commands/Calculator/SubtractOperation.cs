namespace ChatBot.Commands.Calculator;

public class SubtractOperation : ICalculatorOperation
{
    public int Execute(int a, int b) => a - b;
}