using OhMySandwich.Domain.marshallers;
using OhMySandwich.Domain.models;
using OhMySandwich.Domain.ui;

namespace OhMySandwich.CLI;

public class MenuCommand : ICommand
{
    private readonly List<ICommand> _commands;
    private readonly Basket _basket;
    private readonly IMarshaller<Basket> _basketMarshaller;

    public MenuCommand(List<ICommand> commands, Basket basket, IMarshaller<Basket> basketMarshaller)
    {
        _commands = commands;
        _basket = basket;
        _basketMarshaller = basketMarshaller;
    }

    public ICommand? Execute()
    {
        DisplayCurrentBasket();
        DisplayCommandList();

        var input = 0;
        while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out input) || input >= _commands.Count)
        {
            Console.WriteLine("\nWrong input, try again");
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
    }
}