
# Console Application

follow up to [part-1](../part-1/)

inputs:

3. support keywords: 
    - echo:message -> prints message (ex: echo:hello -> prints "hello")
    - calc:expression -> evaluates expression (ex: calc:1+2 -> prints "3")
if none matches print a message (ex: "invalid input" -> prints "the input 'invalid input' cannot be handled")

suggested patterns:
- [Strategy](https://en.wikipedia.org/wiki/Strategy_pattern)


<details>
  <summary>Solution</summary>
  
```cs
// CommandFactory.cs
public class CommandFactory
{
    public ICommand Create(string input)
    {
        if ("exit".Equals(input))
        {
            return new ExitCommand();
        }

        if (input.StartsWith("calc:")) {
            return new CalculatorCommand(input);
        }

        if (input.StartsWith("echo:")) {
            return new EchoCommand(input);
        }

        return new InvalidCommand(input);
    }
}

// CalculatorCommand.cs
public class CalculatorCommand : ICommand
{
    private readonly string _input;
    public EchoCommand(string input) => _input = input;

    public void Execute()
    {
        var parser = new ExpressionParser();
        var (a, b, operation) = parser.Parse(_input); 
        Console.WriteLine(operation.Execute(a, b));
    }
}

// ExpressionParser.cs
public class ExpressionParser
{
    public (int a, int b, ICalculatorOperation operation) Parse(string input)
    {
        string variableA = "", variableB = "";
        ICalculatorOperation operation;
        int i = 0;
        while(i < input.Length && char.IsDigit(input[i]))
        {
            variableA += input[i];
            ++i;
        }
        if (input[i] == "+") operation = new AdditionOperation();
        if (input[i] == "-") operation = new SubtractOperation();
        
        while(i < input.Length && char.IsDigit(input[i]))
        {
            variableB += input[i];
            ++i;
        }

        return (int.Parse(variableA), int.Parse(variableB), operation);
    }
}

// ICalculatorOperation.cs
public interface ICalculatorOperation
{
    int Execute(int a, int b);
}

public class AdditionOperation : ICalculatorOperation
{
    public int Execute(int a, int b) => a + b;
}

```
</details>