
# Console Application

follow up to [part-3](../part-3/)

inputs:

4. support keywords: 
    - clock:enabled -> enable displaying the current time (ex: echo:hello -> prints "16:05:23 - echo:hello" and "hello")
    - clock:disabled -> disable displaying the current time for the following commands

examples:

```sh
bot> logger:enabled
bot> clock:enabled
debug(stopwatch:enabled)
bot> echo:hello world
debug(echo:hello world)
16:05:23 - echo:hello world
hello world
bot> calc:1+2
debug(calc:1+2)
18:15:13 - calc:1+2
3
bot> logger:disable
21:23:54 - logger:disable
debug(logger:disable)
bot> calc:4-2
02:45:23 - calc:4-2
2
bot> stopwatch:disable
11:23:45 - stopwatch:disable
bot> logger:disable
bot> exit
terminal>
```

suggested patterns:
- [Composite](https://en.wikipedia.org/wiki/Composite_pattern#Java)


<details>
  <summary>Solution</summary>
  
```cs

// CompositeCommand.cs
public class CompositeCommand : ICommand
{
    private readonly List<ICommand> _commands = new();
    public void AddCommand(ICommand commmand) => _commands.Add(command);

    public override void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}

// CommandFactoryState.cs
public class CommandFactoryState
{
    public bool StopwatchEnabled { get; set; }
}

// CommandFactory.cs
public class CommandFactory
{
    private readonly CommandFactoryState _state = new();

    public ICommand Create(string input)
    {
        CompositeCommand composite = new();
        if (_state.LoggingEnabled)
        {
            composite.Add(new LoggerCommand(input));
        }

        if (_state.StopwatchEnabled)
        {
            composite.Add(new ClockCommand(input));
        }

        composite.Add(CreateActionCommand(input));
        return composite;
    }

    private ICommand CreateActionCommand(string input)
    {
        if ("exit".Equals(input))
        {
            return new ExitCommand();
        }

        if (input.StartsWith("calc:")) {
            return new CalculatorCommand(input);
        }

        // other commands...

        return new InvalidCommand(input);   
    }
}

```
</details>