namespace ChatBot.Commands;

public class LoggerConfigCommand : ICommand
{
    private readonly CommandFactoryState _state;
    private readonly string _input;
    public LoggerConfigCommand(CommandFactoryState state, string input) => (_state, _input) = (state, input);

    public void Execute()
    {
        if ("logger:enabled".Equals(_input))
        {
            _state.LoggingEnabled = true;
        }
        else if ("logger:disable".Equals(_input))
        {
            _state.LoggingEnabled = false;
        }
    }
}