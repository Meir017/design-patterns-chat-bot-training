namespace ChatBot.Commands;

public class CommandFactory
{
    public ICommand Create(string input)
    {
        if ("exit".Equals(input))
        {
            return new ExitCommand();
        }

        return new EchoCommand(input);
    }
}