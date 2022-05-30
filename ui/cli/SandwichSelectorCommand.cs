using OhMySandwich.marshallers;
using OhMySandwich.models;

namespace OhMySandwich.ui.cli;

public class SandwichSelectorCommand : Command
{
    private readonly Basket _basket;
    private readonly Marshaller<Sandwich> _sandwichMarshaller;
    private readonly Marshaller<Price> _priceMarshaller;
    private readonly List<Sandwich> _sandwichList;

    public SandwichSelectorCommand(Basket basket, Marshaller<Price> priceMarshaller,
        Marshaller<Sandwich> sandwichMarshaller, List<Sandwich> sandwichList)
    {
        _basket = basket;
        _sandwichMarshaller = sandwichMarshaller;
        _priceMarshaller = priceMarshaller;
        _sandwichList = sandwichList;
    }

    public Command? Execute()
    {
        DisplaySandwichList();

        var input = 0;
        while (!int.TryParse(Console.ReadLine(), out input) || input >= _sandwichList.Count)
        {
            Console.WriteLine("Wrong input, try again");
        }

        _basket.AddSandwich(_sandwichList[input]);
        Console.Clear();
        return null;
    }

    public string GetCommandHelp()
    {
        return "Add a sandwich";
    }

    public void Display()
    {
        Console.WriteLine("Choose a Sandwich in the list above :");
    }

    private void DisplaySandwichList()
    {
        for (var i = 0; i < _sandwichList.Count; i++)
        {
            var sandwich = _sandwichList[i];
            Console.WriteLine(
                $"{i} : {_sandwichMarshaller.Serialize(sandwich)}\n" +
                $"Price : {_priceMarshaller.Serialize(sandwich.Price)}");
        }
    }
}