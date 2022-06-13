namespace OhMySandwich.Domain.models;

public class Basket
{
    private readonly List<Sandwich> _sandwichList;

    public Basket()
    {
        _sandwichList = new List<Sandwich>();
    }

    public void AddSandwich(Sandwich sandwich)
    {
        _sandwichList.Add(sandwich);
    }

    public List<Sandwich> GetSandwichList()
    {
        return new List<Sandwich>(_sandwichList);
    }

    public void Reset()
    {
        _sandwichList.Clear();
    }
}