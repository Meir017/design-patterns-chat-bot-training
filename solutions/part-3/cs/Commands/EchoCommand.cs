namespace ChatBot.Commands;

public class EchoCommand : ICommand
{
    private readonly string _input;
    public EchoCommand(string input) => _input = input.Substring("echo:".Length);
    
    public void Execute()
    {
        Console.WriteLine(_input);
    }
}