namespace ChatBot.Commands.Calculator;

public class ExpressionParser
{
    public (int a, int b, char op) Parse(string input)
    {
        var variableA = "";
        var variableB = "";
        var i = 0;
        while(i < input.Length && char.IsDigit(input[i]))
        {
            variableA += input[i];
            ++i;
        }
        char op = input[i++];
        while(i < input.Length && char.IsDigit(input[i]))
        {
            variableB += input[i];
            ++i;
        }

        return (a: int.Parse(variableA), b: int.Parse(variableB), op: op);
    }
}