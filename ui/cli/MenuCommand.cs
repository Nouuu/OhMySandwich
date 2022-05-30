using OhMySandwich.marshallers;
using OhMySandwich.models;

namespace OhMySandwich.ui.cli;

public class MenuCommand : Command
{
    private readonly List<Command> _commands;
    private readonly Basket _basket;
    private readonly Marshaller<Basket> _basketMarshaller;

    public MenuCommand(List<Command> commands, Basket basket, Marshaller<Basket> basketMarshaller)
    {
        _commands = commands;
        _basket = basket;
        _basketMarshaller = basketMarshaller;
    }

    public Command? Execute()
    {
        DisplayCurrentBasket();
        DisplayCommandList();

        var input = 0;
        while (!int.TryParse(Console.ReadLine(), out input) || input >= _commands.Count)
        {
            Console.WriteLine("Wrong input, try again");
        }
        Console.Clear();
        ExecuteAction(input);
        return this;
    }

    public string GetCommandHelp()
    {
        return "Oh My Sandwich Menu";
    }

    public void Display()
    {
        Console.WriteLine("Welcome on OhMySandwich !");
    }

    private void ExecuteAction(int index)
    {
        _commands[index].Display();
        _commands[index].Execute();
    }

    private void DisplayCurrentBasket()
    {
        Console.Write("Current basket : ");
        Console.WriteLine(_basketMarshaller.Serialize(_basket));
    }

    private void DisplayCommandList()
    {
        Console.WriteLine("Available commands : ");
        for (var i = 0; i < _commands.Count; i++)
        {
            Console.WriteLine($"{i} : {_commands[i].GetCommandHelp()}");
        }
        Console.WriteLine();
    }
}