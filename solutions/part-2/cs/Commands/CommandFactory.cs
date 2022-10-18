namespace ChatBot.Commands;

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