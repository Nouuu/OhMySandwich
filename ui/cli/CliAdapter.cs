namespace OhMySandwich.ui.cli;

public class CliAdapter : IAdapter
{
    private readonly ICommand _startCommands;

    public CliAdapter(ICommand startCommand)
    {
        _startCommands = startCommand;
    }

    public void AcceptInteractions()
    {
        var command = _startCommands;
        command.Display();

        while (command != null)
        {
            command = command.Execute();
        }
    }
}