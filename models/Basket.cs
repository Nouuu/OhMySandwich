namespace OhMySandwich.models;

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

    public Invoice? GetInvoice()
    {
        return null;
        
        if (_sandwichList.Count == 0)
        {
            return new Price("", 0);
        }

        return new Price(
            "€", // TODO: Get currency
            _sandwichList.Sum(sandwich => sandwich.Price.Value)
        );
    }
}