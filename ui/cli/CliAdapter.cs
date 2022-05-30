using OhMySandwich.models;

namespace OhMySandwich.ui.cli;

public class CliAdapter : Adapter
{
    private Basket _basket;

    public CliAdapter()
    {
        _basket = new Basket();
    }

    public void AcceptInteractions()
    {
        Menu? nextMenu = null;
        while (nextMenu != null)
        {
            nextMenu.Display();
            // read console input and parse it to int, retry while wrong input
            var input = 0;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Wrong input, try again");
            }

            nextMenu = nextMenu.ExecuteAction(input);
        }
    }
}