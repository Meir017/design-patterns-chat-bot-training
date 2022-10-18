namespace ChatBot.Commands;

public class InvalidCommand : ICommand
{
    private readonly string _input;
    public InvalidCommand(string input) => _input = input;
    
    public void Execute()
    {
        Console.WriteLine($"the input '{_input}' cannot be handled");
    }
}