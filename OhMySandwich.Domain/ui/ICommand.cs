namespace OhMySandwich.Domain.ui;

public interface ICommand
{
    ICommand? Execute();

    string GetCommandHelp();

    void Display();
}