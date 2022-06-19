using OhMySandwich.Domain.models;
using OhMySandwich.Domain.utils;

namespace OhMySandwich.Test.utils;

public class SandwichBuilderShould
{
    [Fact]
    private void build_a_sandwich_with_a_name_and_price_only()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(new Price("€", 5))
            .GetSandwich();

        Assert.Equal("Jambon", sandwich.Name);
        Assert.Equal(new Price("€", 5), sandwich.Price);
    }

    [Fact]
    private void build_a_sandwich_with_a_name_and_default_price_only()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(5)
            .GetSandwich();

        Assert.Equal("Jambon", sandwich.Name);
        Assert.Equal(new Price("€", 5), sandwich.Price);
    }

    [Fact]
    private void throw_an_exception_if_name_is_not_set()
    {
        Assert.Throws<InvalidOperationException>(() => new SandwichBuilder()
            .SetPrice(new Price("€", 5))
            .GetSandwich());
    }

    [Fact]
    private void throw_an_exception_if_price_is_not_set()
    {
        Assert.Throws<InvalidOperationException>(() => new SandwichBuilder()
            .SetName("Jambon")
            .GetSandwich());
    }

    [Fact]
    private void build_a_sandwich_with_a_name_and_price_and_ingredients()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(new Price("€", 5))
            .AddIngredient(new Ingredient("Jambon", UnitType.Slice), 1)
            .AddIngredient(new Ingredient("Tomate", UnitType.Slice), 2)
            .GetSandwich();

        Assert.Equal("Jambon", sandwich.Name);
        Assert.Equal(new Price("€", 5), sandwich.Price);
        Assert.Equal(2, sandwich.Ingredients.Length);
        Assert.Equal(new Ingredient("Jambon", UnitType.Slice), sandwich.Ingredients[0].Ingredient);
        Assert.Equal(1, sandwich.Ingredients[0].Count);
        Assert.Equal(new Ingredient("Tomate", UnitType.Slice), sandwich.Ingredients[1].Ingredient);
        Assert.Equal(2, sandwich.Ingredients[1].Count);
    }

    [Fact]
    private void build_a_sandwich_with_a_name_and_price_and_ingredients_stack()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(new Price("€", 5))
            .AddIngredient(new IngredientStack(new Ingredient("Jambon", UnitType.Slice), 1))
            .GetSandwich();

        Assert.Equal("Jambon", sandwich.Name);
        Assert.Equal(new Price("€", 5), sandwich.Price);
        Assert.Single(sandwich.Ingredients);
        Assert.Equal(new Ingredient("Jambon", UnitType.Slice), sandwich.Ingredients[0].Ingredient);
    }
    
    //fromSandwich Test
    [Fact]
    private void build_a_sandwich_from_a_sandwich()
    {
        var sandwich = new SandwichBuilder()
            .SetName("Jambon")
            .SetPrice(new Price("€", 5))
            .AddIngredient(new Ingredient("Jambon", UnitType.Slice), 1)
            .AddIngredient(new Ingredient("Tomate", UnitType.Slice), 2)
            .GetSandwich();

        var sandwich2 = new SandwichBuilder()
            .FromSandwich(sandwich)
            .GetSandwich();

        Assert.Equal(sandwich.Name, sandwich2.Name);
        Assert.Equal(sandwich.Price, sandwich2.Price);
        Assert.Equal(sandwich.Ingredients.Length, sandwich2.Ingredients.Length);
        Assert.Equal(sandwich.Ingredients[0], sandwich2.Ingredients[0]);
        Assert.Equal(sandwich.Ingredients[1], sandwich2.Ingredients[1]);
        
    }
}