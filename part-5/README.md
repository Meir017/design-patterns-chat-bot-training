
# Console Application

follow up to [part-4](../part-4/)

inputs:

5. Support reading/writing input from:

- Console
  - get input using `Console.ReadLine`
  - write output using `Console.WriteLine`
- File
  - you can assume intput file is `input.txt`
  - you can assume intput file is `output.txt`

examples:

```sh
> chatbot.exe console
bot> echo:hello world
hello world
> chatbot.exe file
```

suggested patterns:
- [Adapter](https://en.wikipedia.org/wiki/Adapter_pattern)

template:

```cs
public class Program
{
    public static void Main()
    {
        IInputOutoutFactory factory = ...
        var (reader, writer) = (factory.CreateReader(), factory.CreateWriter());
        while(true)
        {
            var input = reader.ReadLine();
            // TODO: handle input
            // - create command from factory
            // - execute the command
        }
    }
}

// IInputOutoutFactory.cs
public interface IInputOutoutFactory
{
    // TODO: define the interfaces IInputReader & IOutoutWriter
    IInputReader CreateReader();
    IOutoutWriter CreateWriter();
}
```

<details>
  <summary>Solution</summary>
  
```cs

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please enter an intput/output type (supported: console / file)");
            Console.WriteLine("Usage: chatbot <type>");
            return 1;
        }

        var intputOutputTypeFactory = new InputOutoutTypeFactory();
        IInputOutoutFactory factory = intputOutputTypeFactory.Create(args[0]);
        var (reader, writer) = (factory.CreateReader(), factory.CreateWriter());
        var commandFactory = new CommandFactory();
        while(true)
        {
            var input = reader.ReadLine();
            var command = commandFactory.Create(input, writer);
            command.Execute();
        }
    }
}

// InputOutoutTypeFactory.cs
public class InputOutoutTypeFactory
{
    public IInputOutoutFactory Create(string type)
        => type switch
        {
            "console" => new ConsoleInputOutoutFactory(),
            "file" => new FileInputOutoutFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), $"Not expected direction value: {direction}"),
        }
}

// IInputReader.cs
public interface IInputReader
{
    string ReadLine();
}

// IOutoutWriter.cs
public interface IOutoutWriter
{
    void WriteLine(string message);
}

// ConsoleInputOutoutFactory.cs
public class ConsoleInputOutoutFactory : IInputOutoutFactory
{
    public IInputReader CreateReader() => new ConsoleInputReader();
    pubilc IOutoutWriter CreateWriter() => new ConsoleOutputWriter();
}

// ConsoleInputReader.cs
public class ConsoleInputReader : IInputReader
{
    public string ReadLine() => Console.ReadLine();
}

// ConsoleOutoutWriter.cs
public class ConsoleOutoutWriter : IOutoutWriter
{
    public void WriteLine(string message) => Console.WriteLine(message);
}

// FileInputOutoutFactory.cs
public class FileInputOutoutFactory : IInputOutoutFactory
{
    public IInputReader CreateReader() => new FileInputReader();
    pubilc IOutoutWriter CreateWriter() => new FileOutputWriter();
}

// FileInputReader.cs
public class FileInputReader : IInputReader
{
    private readonly StreamReader reader;

    public FileInputReader()
    {
        reader = File.OpenRead("input.txt");
    }

    public string ReadLine() => reader.ReadLine() ?? "exit";
}

// FileOutoutWriter.cs
public class FileOutoutWriter : IOutoutWriter
{
    private readonly StreamWriter writer;

    public FileOutoutWriter()
    {
        writer = File.CreateText("output.txt");
    }

    public void WriteLine(string message) => writer.WriteLine(message);
}


```
</details>