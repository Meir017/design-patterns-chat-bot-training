namespace ChatBot.Commands;

public class LoggerCommand : ICommand
{
    private readonly string _input;
    private readonly ICommand _command;

    public LoggerCommand(string input, ICommand command)
    {
        _input = input;
        _command = command;
    }

    public void Execute()
    {
        Console.WriteLine($"debug({_input})");
        _command.Execute();
    }
}