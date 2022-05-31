using OhMySandwich.models;

namespace OhMySandwich.ui.cli;

public class NewOrderCommand : Command
{
    private readonly Basket _basket;

    public NewOrderCommand(Basket basket)
    {
        _basket = basket;
    }

    public Command? Execute()
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