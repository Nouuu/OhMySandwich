namespace OhMySandwich.ui.cli;

public abstract class Menu
{
    private readonly List<Command> _commands;
    private readonly string _message;

    protected Menu(List<Command> commands, string message)
    {
        _commands = commands;
        this._message = message;
    }

    public void Display()
    {
        Console.WriteLine(_message);
    }

    public Menu? ExecuteAction(int index)
    {
        return _commands[index].Execute();
    }
}