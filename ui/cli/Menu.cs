namespace OhMySandwich.ui.cli;

public abstract class Menu
{
    private List<Command> _commands;
    private string message;

    protected Menu(List<Command> commands, string message)
    {
        _commands = commands;
        this.message = message;
    }

    public void display()
    {
        Console.WriteLine(message);
        
    }

    public Menu executeAction(int index)
    {
        return _commands[index].Execute();
    }
}