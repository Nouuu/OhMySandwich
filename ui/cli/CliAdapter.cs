namespace OhMySandwich.ui.cli;

public class CliAdapter : Adapter
{
    private readonly Command _startCommands;

    public CliAdapter(Command startCommand)
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