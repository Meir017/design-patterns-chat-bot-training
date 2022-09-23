
# Console Application

inputs:

1. echo the input string (using simple `Console.WriteLine`)
2. if the input is "exit", exit the program (using `Environment.Exit(0)`)

examples:

```sh
bot> hello world
hello world
bot> testing testing
testing testing
bot> exit
terminal>
```

template:

```cs
public class Program
{
    public static void Main()
    {
        while(true)
        {
            var input = Console.ReadLine();
            // TODO: handle input
        }
    }
}
```

suggested patterns:
- [Factory](https://en.wikipedia.org/wiki/Factory_method_pattern)


<details>
  <summary>Solution</summary>
  
```cs
public class Program
{
    public static void Main()
    {
        var commandFactory = new CommandFactory();
        while(true)
        {
            var input = Console.ReadLine();
            var command = commandFactory.Create(input);
            command.Execute();
        }
    }
}

// CommandFactory.cs
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


// ICommand.cs
public interface ICommand
{
    void Execute();
}

// EchoCommand.cs
public class EchoCommand : ICommand
{
    private readonly string _input;
    public EchoCommand(string input) => _input = input;

    public void Execute()
    {
        Console.WriteLine(_input);
    }
}

// ExitCommand.cs
public class ExitCommand : ICommand
{
    public void Execute()
    {
        Environment.Exit(0);
    }
}
```
</details>