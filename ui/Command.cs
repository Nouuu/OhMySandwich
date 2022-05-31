using OhMySandwich.ui.cli;

namespace OhMySandwich.ui;

public interface Command
{
    Command? Execute();
    
    string GetCommandHelp();

    void Display();
    
}