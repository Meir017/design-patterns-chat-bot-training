namespace ChatBot.Commands;

public class CommandFactory
{
    private readonly CommandFactoryState _state = new();

    public ICommand Create(string input)
    {
        ICommand command = CreateBase(input);
        if (_state.LoggingEnabled)
        {
            return new LoggerCommand(input, command);
        }

        return command;
    }

    private ICommand CreateBase(string input)
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

        if (input.StartsWith("logger:")) 
        {
            return new LoggerConfigCommand(_state, input);
        }

        return new InvalidCommand(input);   
    }
}