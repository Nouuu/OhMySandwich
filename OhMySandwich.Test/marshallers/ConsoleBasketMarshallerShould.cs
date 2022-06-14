using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;
using OhMySandwich.Infrastructure.marshallers;

namespace OhMySandwich.Test.marshallers;

public class ConsoleBasketMarshallerShould
{
    [Fact]
    private void show_nothing_when_empty()
    {
        var basket = new Basket();
        var marshaller = new ConsoleBasketMarshaller();
        var result = marshaller.Serialize(basket);
        Assert.Equal("", result);
    }
    
    
    [Fact]
    private void show_one_sandwich_when_contains_one()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .GetSandwich();
        var basket = new Basket();
        basket.AddSandwich(sandwich);
        
        var marshaller = new ConsoleBasketMarshaller();
        
        var result = marshaller.Serialize(basket);
        Assert.Equal("\n- Jambon", result);
    }
    [Fact]
    private void show_two_sandwichs_when_contains_two()
    {
        var sandwich1 = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(0)
            .GetSandwich();
        var sandwich2 = new SandwichBuilder()
            .SetName("Poulet")
            .SetPrice(0)
            .GetSandwich();
        var basket = new Basket();
        basket.AddSandwich(sandwich1);
        basket.AddSandwich(sandwich2);
        
        var marshaller = new ConsoleBasketMarshaller();
        Assert.Equal("\n- Jambon\n- Poulet", marshaller.Serialize(basket));
    }
}