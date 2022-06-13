using System.Text;
using OhMySandwich.Domain.ui;

namespace OhMySandwich.CLI;

public class CliAdapter : IAdapter
{
    private readonly ICommand _startCommands;

    public CliAdapter(ICommand startCommand)
    {
        _startCommands = startCommand;
    }

    public void AcceptInteractions()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var command = _startCommands;
        command.Display();

        while (command != null)
        {
            command = command.Execute();
        }
    }
}