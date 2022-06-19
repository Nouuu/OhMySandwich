using OhMySandwich.Domain.models;
using OhMySandwich.Domain.ui;

namespace OhMySandwich.CLI;

public class NewOrderCommand : ICommand
{
    private readonly Basket _basket;

    public NewOrderCommand(Basket basket)
    {
        _basket = basket;
    }

    public ICommand? Execute()
    {
        _basket.Reset();
        return null;
    }

    public string GetCommandHelp()
    {
        return "New order";
    }

    public void Display()
    {
        Console.WriteLine("Clearing the basket for new order");
    }
}