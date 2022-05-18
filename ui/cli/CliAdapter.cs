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
        Menu nextMenu = null;
        while (nextMenu != null)
        {
            nextMenu.display();
            // TODO read user input
            nextMenu = nextMenu.executeAction(0);
        }
    }
}