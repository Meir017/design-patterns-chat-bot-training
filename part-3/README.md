
# Console Application

follow up to [part-1](../part-1/)

inputs:

4. support keywords: 
    - logger:enabled -> enable logging for the following commands (ex: echo:hello -> prints "debug(echo:hello)" and "hello")
    - logger:disabled -> disable logging for the following commands

examples:

```sh
bot> logger:enabled
bot> echo:hello world
debug(echo:hello world)
hello world
bot> calc:1+2
debug(calc:1+2)
3
bot> logger:disable
debug(logger:disable)
bot> calc:4-2
2
bot> logger:disable
bot> exit
terminal>
```

suggested patterns:
- [Decorator](https://en.wikipedia.org/wiki/Decorator_pattern)


<details>
  <summary>Solution</summary>
  
```cs
// CommandFactoryState.cs
public class CommandFactoryState
{
    public bool LoggingEnabled { get; set; }
}

// CommandFactory.cs
public class CommandFactory
{
    private readonly CommandFactoryState _state = new CommandFactoryState();

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

public class LoggerConfigCommand : ICommand
{
    private readonly string _input;
    private readonly CommandFactoryState _state;
    public LoggerConfigCommand(string input, CommandFactoryState state) => (_input, _state) = (input, state);

    public void Execute()
    {
        if ("logger:enabled".Equals(_input))
        {
            _state.LoggingEnabled = true;
        }
        else if ("logger:disabled".Equals(_input))
        {
            _state.LoggingEnabled = false;
        }
    }
}

// LoggerCommand.cs
public class LoggerCommand : ICommand
{
    private readonly string _input;
    private readonly ICommand _command;
    public EchoCommand(ICommand command, string input) => (_input, _command) = (input, command);

    public void Execute()
    {
        Console.WriteLine($"debug({_input})");
        _command.Execute();
    }
}

```
</details>