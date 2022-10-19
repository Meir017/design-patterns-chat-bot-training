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
            return new CalculatorCommand(input.Substring("calc:".Length));
        }

        if (input.StartsWith("echo:")) {
            return new EchoCommand(input.Substring("echo:".Length));
        }

        return new InvalidCommand(input);
    }
}