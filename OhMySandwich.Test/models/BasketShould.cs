using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;

namespace OhMySandwich.Test.models;

public class BasketShould
{
    readonly Sandwich sandwich1 = new SandwichBuilder()
        .SetName("Jambon")
        .SetPrice(new Price("€", 5))
        .GetSandwich();

    readonly Sandwich sandwich2 = new SandwichBuilder()
        .SetName("Beurre")
        .SetPrice(new Price("€", 2))
        .GetSandwich();

    [Fact]
    public void instantiate_without_sandwiches()
    {
        var basket = new Basket();
        Assert.Empty(basket.GetSandwichList());
    }
    
    [Fact]
    public void add_sandwich_to_basket()
    {
        var basket = new Basket();
        basket.AddSandwich(sandwich1);
        basket.AddSandwich(sandwich2);
        Assert.Contains(sandwich1, basket.GetSandwichList());
        Assert.Contains(sandwich2, basket.GetSandwichList());
    }
    
    [Fact]
    public void reset_basket()
    {
        var basket = new Basket();
        basket.AddSandwich(sandwich1);
        basket.AddSandwich(sandwich2);
        basket.Reset();
        Assert.Empty(basket.GetSandwichList());
    }
}