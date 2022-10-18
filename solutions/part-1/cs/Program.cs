using ChatBot.Commands;

Console.WriteLine("Welcome to the ChatBot!");
var commandFactory = new CommandFactory();
while(true)
{
    Console.Write("> ");
    var input = Console.ReadLine()!;
    var command = commandFactory.Create(input);
    command.Execute();
}