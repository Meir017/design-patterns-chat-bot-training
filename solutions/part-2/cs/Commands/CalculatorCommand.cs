using ChatBot.Commands.Calculator;

namespace ChatBot.Commands;

public class CalculatorCommand : ICommand
{
    private readonly string _input;
    public CalculatorCommand(string input) => _input = input.Substring("calc:".Length);

    public void Execute()
    {
        var parser = new ExpressionParser();
        var (a, b, op) = parser.Parse(_input);
        var operation = GetOperation(op);
        Console.WriteLine(operation.Execute(a, b));
    }

    private ICalculatorOperation GetOperation(char op) => op switch
    {
        '+' => new AdditionOperation(),
        '-' => new SubtractOperation(),
        _ => throw new ArgumentOutOfRangeException()
    };
}