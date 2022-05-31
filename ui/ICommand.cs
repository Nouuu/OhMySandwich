using OhMySandwich.ui.cli;

namespace OhMySandwich.ui;

public interface ICommand
{
    ICommand? Execute();
    
    string GetCommandHelp();

    void Display();
    
}